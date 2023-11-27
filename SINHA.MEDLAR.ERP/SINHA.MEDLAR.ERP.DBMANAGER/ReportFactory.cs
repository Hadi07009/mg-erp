using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Web.UI;
using System.IO;

namespace SINHA.MEDLAR.ERP.DBMANAGER
{
    public static class ReportFactory
    {
        static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, UserReport>> _sessions = new ConcurrentDictionary<string, ConcurrentDictionary<string, UserReport>>();

        /// <summary>
        /// Creates the report dispose on unload.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page">The page.</param>
        /// <returns>``0.</returns>
        public static T CreateReportDisposeOnUnload<T>(this Page page) where T : IDisposable, new()
        {
            var report = new T();
            DisposeOnUnload(page, report);
            return report;
        }

        /// <summary>
        /// Disposes on page unload.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page">The page.</param>
        /// <param name="instance">The instance.</param>
        private static void DisposeOnUnload<T>(this Page page, T instance) where T : IDisposable
        {
            page.Unload += (s, o) =>
            {
                if (instance != null)
                {
                    CloseAndDispose(instance);
                }
            };
        }

        /// <summary>
        /// Unloads the report when user navigates away from report.
        /// </summary>
        /// <param name="page">The page.</param>
        public static void UnloadReportWhenUserNavigatesAwayFromPage(this Page page)
        {
            var sessionId = page.Session.SessionID;
            var pageName = Path.GetFileName(page.Request.Url.AbsolutePath);

            var contains = _sessions.ContainsKey(sessionId);

            if (contains)
            {
                var reports = _sessions[sessionId];
                var report = reports.Where(r => r.Value.PageName != pageName).ToList();

                foreach (var userReport in report)
                {
                    UserReport instance;

                    bool removed = reports.TryRemove(userReport.Key, out instance);

                    if (removed)
                    {
                        CloseAndDispose(instance.Report);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ReportClass.</returns>
        public static T CreateReportForCrystalReportViewer<T>(this Page page) where T : IDisposable, new()
        {
            var report = CreateReport<T>(page);
            return report;
        }

        /// <summary>
        /// Creates the report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page">The page.</param>
        /// <returns>``0.</returns>
        private static T CreateReport<T>(Page page) where T : IDisposable, new()
        {
            MoreThan70ReportsFoundRemoveOldestReport();

            var sessionId = page.Session.SessionID;

            bool containsKey = _sessions.ContainsKey(sessionId);
            var reportKey = typeof(T).FullName;
            var newReport = GetUserReport<T>(page);

            if (containsKey)
            {
                //Get user by session id
                var reports = _sessions[sessionId];

                //check for the report, remove it and dispose it if it exists in the collection
                RemoveReportWhenMatchingTypeFound<T>(reports);

                //add the report to the collection

                reports.TryAdd(reportKey, newReport);

                //add the reports to the user key in the concurrent dictionary
                _sessions[sessionId] = reports;
            }
            else //key does not exist in the collection
            {
                var newDictionary = new ConcurrentDictionary<string, UserReport>();
                newDictionary.TryAdd(reportKey, newReport);

                _sessions[sessionId] = newDictionary;

            }

            return (T)newReport.Report;
        }

        /// <summary>
        /// Ifs the more than 70 reports remove the oldest report.
        /// </summary>
        private static void MoreThan70ReportsFoundRemoveOldestReport()
        {
            var reports = _sessions.SelectMany(r => r.Value).ToList();

            if (reports.Count() > 70)
            {
                //order the reports with the oldest on top.
                var sorted = reports.OrderByDescending(r => r.Value.TimeAdded);

                //remove the oldest
                var first = sorted.FirstOrDefault();
                var key = first.Key;
                var sessionKey = first.Value.SessionId;

                if (first.Value != null)
                {
                    //close and depose of the first report
                    CloseAndDispose(first.Value.Report);

                    var dictionary = _sessions[sessionKey];
                    var containsKey = dictionary.ContainsKey(key);

                    if (containsKey)
                    {
                        //remove the disposed report from the collection
                        UserReport report;
                        dictionary.TryRemove(key, out report);
                    }
                }

            }
        }

        /// <summary>
        /// Removes the report if there is a report with a match type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reports">The reports.</param>
        private static void RemoveReportWhenMatchingTypeFound<T>(ConcurrentDictionary<string, UserReport> reports) where T : IDisposable, new()
        {
            var key = typeof(T).FullName;
            var containsKey = reports.ContainsKey(key);

            if (containsKey)
            {
                UserReport instance;

                bool removed = reports.TryRemove(key, out instance);

                if (removed)
                {
                    CloseAndDispose(instance.Report);
                }

            }
        }

        /// <summary>
        /// Removes the reports for session.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        public static void RemoveReportsForSession(string sessionId)
        {
            var containsKey = _sessions.ContainsKey(sessionId);

            if (containsKey)
            {
                ConcurrentDictionary<string, UserReport> session;

                var removed = _sessions.TryRemove(sessionId, out session);

                if (removed)
                {
                    foreach (var report in session.Where(r => r.Value.Report != null))
                    {
                        CloseAndDispose(report.Value.Report);
                    }
                }
            }
        }

        /// <summary>
        /// Closes the and dispose.
        /// </summary>
        /// <param name="report">The report.</param>
        private static void CloseAndDispose(IDisposable report)
        {
            report.Dispose();
        }

        /// <summary>
        /// Gets the user report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>UserReport.</returns>
        private static UserReport GetUserReport<T>(Page page) where T : IDisposable, new()
        {
            string onlyPageName = Path.GetFileName(page.Request.Url.AbsolutePath);

            var report = new T();
            var userReport = new UserReport { PageName = onlyPageName, TimeAdded = DateTime.UtcNow, Report = report, SessionId = page.Session.SessionID };

            return userReport;
        }

        /// <summary>
        /// Removes all reports.
        /// </summary>
        public static void RemoveAllReports()
        {
            foreach (var session in _sessions)
            {
                foreach (var report in session.Value)
                {
                    if (report.Value.Report != null)
                    {
                        CloseAndDispose(report.Value.Report);
                    }
                }

                //remove all the disposed reports
                session.Value.Clear();
            }

            //empty the collection
            _sessions.Clear();
        }

        private class UserReport
        {
            /// <summary>
            /// Gets or sets the time added.
            /// </summary>
            /// <value>The time added.</value>
            public DateTime TimeAdded { get; set; }

            /// <summary>
            /// Gets or sets the report.
            /// </summary>
            /// <value>The report.</value>
            public IDisposable Report { get; set; }

            /// <summary>
            /// Gets or sets the session identifier.
            /// </summary>
            /// <value>The session identifier.</value>
            public string SessionId { get; set; }

            /// <summary>
            /// Gets or sets the name of the page.
            /// </summary>
            /// <value>The name of the page.</value>
            public string PageName { get; set; }
        }
    }
}
