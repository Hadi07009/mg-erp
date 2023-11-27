<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SewingDefectEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SewingDefectEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {

            $('input:text:first').focus();
            $('input:text,select').bind("keydown", function (e) {
                var n = $("input:text,select").length;
                if (e.which == 13) { //Enter key

                    e.preventDefault(); //Skip default behavior of the enter key

                    var nextIndex = $('input:text,select').index(this) + 1;

                    if (nextIndex < n)

                    { $('input:text,select')[nextIndex].focus(); }

                    else {

                        $('input:text,select')[nextIndex - 1].blur();

                        $('#btnSave').click();

                    }

                }

            });
        
    </script>
    <script type="text/javascript" language="javascript">

        function controlEnter(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 13) {

                document.getElementById(obj).focus();

                return false;

            }

            else {

                return true;

            }

        }

    </script>
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <script type="text/javascript">
        function TextName_OnKeyDown(e) {
            var keynum
            if (window.event) // IE
            {
                keynum = e.keyCode
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                keynum = e.which
            }
            if (keynum == 13) {
                document.getElementById('<%= btnSave.ClientID %>').click();
            }
        }
    </script>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtHourNo.ClientID %>").focus(); }) 
    </script>
    <table class="style1">
        <tr>
            <td style="width: 342px; height: 15px">
                <asp:Label ID="lblHeadOfficeName" runat="server" Text="Office Name" Font-Bold="True"
                    Font-Size="Small" Font-Names="Tahoma" Style="color: #0000FF"></asp:Label>
            </td>
            <td style="height: 15px">
                <asp:Label ID="lblHeadOfficeAddress" runat="server" Text="Head Office  Address" Font-Bold="True"
                    Font-Size="Small" Style="color: #0000FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 342px">
                <asp:Label ID="lblBranchOfficeName" runat="server" Text="Office Name" Font-Bold="True"
                    Font-Size="Small" Font-Names="Tahoma" Style="color: #0000FF"></asp:Label>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblBranchOfficeAddress" runat="server" Text="Branch Office Address"
                    Font-Bold="True" Font-Size="Small" Style="color: #0000FF"></asp:Label>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <fieldset>
        <legend>SEWING DEFECT ENTRY</legend>
        <table style="width: 99%; height: 441px; font-weight: 700;">
            <tr>
                <td style="text-align: left;" colspan="6" class="style3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 19px;">
                    <asp:Label ID="Label39" runat="server" Font-Bold="False" Text="ID :"></asp:Label>
                </td>
                <td style="width: 108px; height: 19px;">
                    <asp:TextBox ID="txtSewingDefectentryId" runat="server" BackColor="Yellow" Width="50px"></asp:TextBox>
                </td>
                <td style="height: 19px; width: 101px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 11px;">
                    <asp:Label ID="Label40" runat="server" Font-Bold="False" Text="Date :"></asp:Label>
                </td>
                <td style="width: 108px; height: 11px;">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="date" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="height: 11px; width: 101px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Line :"></asp:Label>
                </td>
                <td style="height: 11px; width: 74px">
                    <asp:DropDownList ID="ddlLineId" runat="server" Width="117px" Height="16px">
                    </asp:DropDownList>
                </td>
                <td style="height: 11px; width: 80px">
                </td>
                <td style="height: 11px; width: 70px;">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 5px;">
                    <asp:Label ID="Label52" runat="server" Font-Bold="False" Text="Hour :"></asp:Label>
                </td>
                <td style="width: 108px; height: 5px;">
                    <asp:TextBox ID="txtHourNo" runat="server" Height="16px" Width="115px"></asp:TextBox>
                </td>
                <td style="height: 5px; width: 101px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Total Chk Qty:"></asp:Label>
                </td>
                <td style="height: 5px; width: 74px">
                    <asp:TextBox ID="txtTotalCheckQuantity" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="height: 5px; width: 80px">
                    </td>
                <td style="height: 5px; width: 70px;">
                    </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 5px;">
                    <asp:Label ID="Label54" runat="server" Font-Bold="False" Text="Production:"></asp:Label>
                </td>
                <td style="width: 108px; height: 5px;">
                    <asp:TextBox ID="txtProductionQuantity" runat="server" Height="16px" 
                        Width="115px"></asp:TextBox>
                </td>
                <td style="height: 5px; width: 101px">
                    &nbsp;</td>
                <td style="height: 5px; width: 74px">
                    &nbsp;</td>
                <td style="height: 5px; width: 80px">
                    &nbsp;</td>
                <td style="height: 5px; width: 70px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; height: 14px;" colspan="6">
                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Italic="False" Text="ADD FABRIC DEFECT"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 28px;">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Shading :"></asp:Label>
                </td>
                <td style="width: 108px; height: 28px;">
                    <asp:TextBox ID="txtShading" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 28px; width: 101px;">
                    <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Damage/Hole :"></asp:Label>
                </td>
                <td style="height: 28px; width: 74px;">
                    <asp:TextBox ID="txtDamageHole" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 28px; width: 80px;">
                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Fabric Defect :"></asp:Label>
                </td>
                <td style="height: 28px; width: 70px;">
                    <asp:TextBox ID="txtFabricDefect" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 12px;" colspan="6">
                    <asp:Label ID="Label44" runat="server" Font-Bold="True" Text="SEWING STITCH DEFECT"
                        Font-Italic="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 8px">
                    <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Open/Inc.Stitch :"></asp:Label>
                </td>
                <td style="width: 108px; height: 21px;">
                    <asp:TextBox ID="txtOpenInsecureStitch" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="height: 8px; width: 101px" class="style3">
                    <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="Broken Stitch :" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="height: 8px; width: 74px;">
                    <asp:TextBox ID="txtBrokenStitch" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 8px; width: 80px;">
                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="Skip Stitch :"></asp:Label>
                </td>
                <td style="height: 21px; width: 70px;">
                    <asp:TextBox ID="txtSkipStitch" runat="server" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 4px;">
                    <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Missing  :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 108px; height: 4px;">
                    <asp:TextBox ID="txtMissing" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 4px; width: 101px;">
                    <asp:Label ID="Label10" runat="server" Font-Bold="False" 
                        Text="Unevn Ed Mrg/Wd :"></asp:Label>
                </td>
                <td style="width: 74px; height: 4px">
                    <asp:TextBox ID="txtUnevenEdgeMarginWidth" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="width: 80px; height: 4px">
                    <asp:Label ID="Label11" runat="server" Font-Bold="False" 
                        Text="Jn Sth/Por Rep :"></asp:Label>
                </td>
                <td style="height: 4px; width: 70px;">
                    <asp:TextBox ID="txtJoinStitchPoorRepier" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 14px;">
                    <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="Ovr/ Dwn Stch :"></asp:Label>
                </td>
                <td style="width: 108px; height: 14px;">
                    <asp:TextBox ID="txtOverDownStitch" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 14px; width: 101px">
                    <asp:Label ID="Label13" runat="server" Font-Bold="False" Text="Tensn Tight/Loose :"></asp:Label>
                </td>
                <td style="height: 14px; width: 74px">
                    <asp:TextBox ID="txtTensionTightLoose" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="height: 14px; width: 80px">
                    <asp:Label ID="Label14" runat="server" Font-Bold="False" Text="Pleat :"></asp:Label>
                </td>
                <td style="height: 14px; width: 70px;">
                    <asp:TextBox ID="txtPleat" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 20px;">
                    <asp:Label ID="Label19" runat="server" Font-Bold="False" Text="Ctg by Seam :"></asp:Label>
                </td>
                <td style="width: 108px; height: 20px;">
                    <asp:TextBox ID="txtCaughtBySeen" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 20px; width: 101px">
                    <asp:Label ID="Label20" runat="server" Font-Bold="False" Text="Aattched By Bartck :"></asp:Label>
                </td>
                <td style="height: 20px; width: 74px">
                    <asp:TextBox ID="txtAttachedByBartrack" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="height: 20px; width: 80px">
                    <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="Rawedg/Frying :"></asp:Label>
                </td>
                <td style="height: 20px; width: 70px;">
                    <asp:TextBox ID="txtRawedgeFraying" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 4px;">
                    <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Excs/Less Inlay:"></asp:Label>
                </td>
                <td style="width: 108px; height: 4px;">
                    <asp:TextBox ID="txtExcessLessInlay" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 4px; width: 101px">
                </td>
                <td style="height: 4px; width: 74px">
                </td>
                <td style="height: 4px; width: 80px">
                </td>
                <td class="style3" style="height: 4px; width: 70px;">
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 18px;" colspan="6">
                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Italic="False" Text="AESTHETIC DEFECT"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 21px;">
                    <asp:Label ID="Label23" runat="server" Font-Bold="False" Text="Poor Shape :"></asp:Label>
                </td>
                <td style="width: 108px; height: 21px;">
                    <asp:TextBox ID="txtPoorShape" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 101px">
                    <asp:Label ID="Label24" runat="server" Font-Bold="False" 
                        Text="Puckring/Loseness :"></asp:Label>
                    &nbsp;</td>
                <td style="height: 21px; width: 74px">
                    <asp:TextBox ID="txtPuckingLooseness" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 80px">
                    <asp:Label ID="Label25" runat="server" Font-Bold="False" Text="Roping/Wavy:"></asp:Label>
                </td>
                <td class="style3" style="height: 21px; width: 70px;">
                    <asp:TextBox ID="txtRopingWavy" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 13px;">
                    <asp:Label ID="Label26" runat="server" Font-Bold="False" Text="Slanted :"></asp:Label>
                </td>
                <td style="width: 108px; height: 13px;">
                    <asp:TextBox ID="txtStanted" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 13px; width: 101px">
                    <asp:Label ID="Label27" runat="server" Font-Bold="False" Text="High King :" 
                        style="text-align: right"></asp:Label>
                </td>
                <td style="height: 13px; width: 74px">
                    <asp:TextBox ID="txtHighKing" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 13px; width: 80px">
                    <asp:Label ID="Label28" runat="server" Font-Bold="False" Text="Pnl HiLw/Updn :"></asp:Label>
                </td>
                <td class="style3" style="height: 13px; width: 70px;">
                    <asp:TextBox ID="txtPanelHilowUpdown" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 9px;">
                    <asp:Label ID="Label29" runat="server" Font-Bold="False" Text="Panel Reverse :"></asp:Label>
                </td>
                <td style="width: 108px; height: 9px;">
                    <asp:TextBox ID="txtPanelReverse" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 9px; width: 101px">
                    <asp:Label ID="Label30" runat="server" Font-Bold="False" Text="Projection :"></asp:Label>
                </td>
                <td style="height: 9px; width: 74px">
                    <asp:TextBox ID="txtProjection" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 9px; width: 80px">
                    <asp:Label ID="Label31" runat="server" Font-Bold="False" 
                        Text="Umtch Pair Ubl :"></asp:Label>
                </td>
                <td class="style3" style="height: 9px; width: 70px;">
                    <asp:TextBox ID="txtUnmatchPairUnBalance" runat="server" Width="115px" 
                        Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 21px;" colspan="6">
                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="DIRTY &amp; STAIN"
                        Font-Italic="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 21px;">
                    <asp:Label ID="Label32" runat="server" Font-Bold="False" Text="Oil Mark:"></asp:Label>
                </td>
                <td style="width: 108px; height: 21px;">
                    <asp:TextBox ID="txtOilMark" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 101px">
                    <asp:Label ID="Label41" runat="server" Font-Bold="False" Text="Spot/ Dirty:"></asp:Label>
                </td>
                <td style="height: 21px; width: 74px">
                    <asp:TextBox ID="txtSpotDirty" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 80px">
                </td>
                <td class="style3" style="height: 21px; width: 70px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 15px;" colspan="6">
                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Italic="False" Text="MEASUREMENT DISCREPANCY OOT +/-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 21px;">
                    <asp:Label ID="Label34" runat="server" Font-Bold="False" Text="Miss/MisPlace :"></asp:Label>
                </td>
                <td style="width: 108px; height: 21px;">
                    <asp:TextBox ID="txtMissPlace" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 101px">
                    <asp:Label ID="Label35" runat="server" Font-Bold="False" 
                        Text="Po/Mn/Sz Lb/Mistk :"></asp:Label>
                </td>
                <td style="height: 21px; width: 74px">
                    <asp:TextBox ID="txtPo" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 80px">
                    <asp:Label ID="Label42" runat="server" Font-Bold="False" Text="Chest/ Waist :"></asp:Label>
                </td>
                <td class="style3" style="height: 21px; width: 70px;">
                    <asp:TextBox ID="txtChestWaist" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 3px;">
                    <asp:Label ID="Label36" runat="server" Font-Bold="False" Text="F/bck Len/Thigh:"></asp:Label>
                </td>
                <td style="width: 108px; height: 3px;">
                    <asp:TextBox ID="txtFBack" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 3px; width: 101px">
                    <asp:Label ID="Label37" runat="server" Font-Bold="False" Text="Slv Length/Inseam:"></asp:Label>
                </td>
                <td style="height: 3px; width: 74px">
                    <asp:TextBox ID="txtSlvLengthInseam" runat="server" Width="115px" Height="16px"></asp:TextBox>
                </td>
                <td style="height: 3px; width: 80px">
                    <asp:Label ID="Label38" runat="server" Font-Bold="False" Text="Sweep/Hip :"></asp:Label>
                </td>
                <td class="style3" style="height: 3px; width: 70px;">
                    <asp:TextBox ID="txtsweepHip" runat="server" Width="115px" onkeydown="javascript:TextName_OnKeyDown(event)"
                        Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 87px; height: 6px;">
                </td>
                <td style="text-align: left; width: 108px; height: 6px;">
                </td>
                <td style="height: 6px; width: 101px">
                </td>
                <td style="height: 6px; width: 74px">
                </td>
                <td style="height: 6px; width: 80px">
                </td>
                <td class="style3" style="height: 6px; width: 70px;">
                </td>
            </tr>
            <tr>
                <td style="text-align: center; height: 34px;" colspan="6">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" 
                        Width="66px" CssClass="styled-button-4"
                        OnClick="btnDelete_Click" />
                </td>
            </tr>
                   <tr>
                                <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1" style="height: 61px">
                                            <tr>
                                                <td style="width: 118px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label49" runat="server" Text="From Date :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="149px" BackColor="White" placeHolder="FROM DATE"
                                                        CssClass="date"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 131px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="63px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label51" runat="server" Text="Line :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                    <asp:DropDownList ID="ddlLineIdSearch" runat="server" Width="148px" Height="22px">
                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 118px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label50" runat="server" Text="To Date :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:TextBox ID="dtpToDate" runat="server" Width="149px" BackColor="White" placeHolder="TO DATE"
                                                        CssClass="date"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 131px;">
                                                    &nbsp;</td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label53" runat="server" Text="Hour :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtHourNoSearch" runat="server" Width="149px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            </table>
                                    </fieldset>
                                </td>
                            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend style="font-weight: 700">SEWING DEFECT ENTRY RESULT </legend>
        <div id="divGridViewScroll" style="width: 1011px;  overflow: scroll">
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                            GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                            AllowSorting="True" EnableViewState="True" AlternatingRowStyle-CssClass="alt"
                            OnPageIndexChanging="gvUnit_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                            OnSelectedIndexChanged="OnSelectedIndexChanged" CausesValidation="false" 
                            OnRowEditing="gvUnit_RowEditing" Width="993px">
                            <Columns>
                              
                                <asp:BoundField DataField="SEWING_DEFECT_ENTRY_ID" HeaderText="ID" />
                                <asp:BoundField DataField="DEFECT_DATE" HeaderText="DATE" Visible="True" />
                                <asp:BoundField DataField="LINE_NAME" HeaderText="LINE" />
                                  <asp:BoundField DataField="HOUR_NO" HeaderText="HOUR" />
                                <asp:BoundField DataField="TOTAL_CHECK_QTY" HeaderText="CHECK QUANTITY" />
                                 <asp:BoundField DataField="PRODUCTION_QUANTITY" HeaderText="PRODUCTION" />
                                <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                            Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
