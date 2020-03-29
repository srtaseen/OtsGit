<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LineBookingToolCA.aspx.cs" Inherits="LineBookingToolCA" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" src="Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Scripts/modal.js"></script>
    <link href="Styles/main.css" type="text/css" rel="stylesheet"/>

    <script type="text/javascript">
        /* Event editing helpers - modal dialog */
        function dialog() {
            var modal = new DayPilot.Modal();            
            modal.onClosed = function (args) {
                window.console && console.log(args);
                if (args.result == "OK") {
                    dps1.commandCallBack('refresh');
                }
                dps1.clearSelection();
            };
            return modal;
        }

        function eventClick(e) {
	    var modal = dialog();
	    modal.showUrl("LineBEvent.aspx?id=" + e.value());
	    
        }

        //function editEvent(e) {
        //    var modal = new DayPilot.Modal();
        //    modal.top = 60; // position of the dialog top (y), relative to the visible area
        //    modal.width = 300; // width of the dialog
        //    modal.height = 250; // height of the dialog
        //    modal.opacity = 70; // opacity of the background
        //    modal.border = "10px solid #d0d0d0";  // dialog box border
        //    modal.closed = function () { // callback executed after the dialog is closed
        //        if (this.result == "OK") {  // if the
        //            dp.commandCallBack('refresh');
        //        }
        //    };
        //}
    </script>

    <style type="text/css">
        /*  modal popup */
        .modalBackground {
	        background-color:Gray;
	        filter:alpha(opacity=70);
	        opacity:0.7;
        }

        .modalPopup {
	        background-color:#ffffff;
	        border-width:3px;
	        border-style:solid;
	        border-color:Gray;
	        padding:3px;
	        width:250px;
            
        }    
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


 <div style="padding: 2px; margin: 0px; border-bottom-style: solid; height:25px; border-bottom-width: 0px; border-bottom-color: #006699; background-color: #3a5795;" >
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MhyperLnk" BackColor="#FFFF95" Width="5%"
                    NavigateUrl="~/page2.aspx"><i class="fa fa-home"></i> HOME</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="MhyperLnk" width="5%"
                    BackColor="#ECF1FF" NavigateUrl="~/Page39.aspx"><i class="fa fa-bars"></i>ENTRY</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" CssClass="MhyperLnk" width="10%"
                    BackColor="#ECF1FF" NavigateUrl="~/LineBooking2.aspx"><i class="fa fa-bars"></i> LINE BOOKING</asp:HyperLink>
                     <asp:HyperLink ID="HyperLink6" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP5.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION ENTRY</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/HP4_Report.aspx"><i class="fa fa-bars"></i> HOURLY PRODUCTION REPORT</asp:HyperLink>

             <asp:HyperLink ID="HyperLink4" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/PlanningDashboard.aspx"><i class="fa fa-bars"></i> PRODUCTION DASHBOARD</asp:HyperLink>

                 <asp:HyperLink ID="HyperLink7" runat="server" CssClass="MhyperLnk" width="20%"
                    BackColor="#ECF1FF" NavigateUrl="~/LineBookingTool.aspx"><i class="fa fa-bars"></i> PLANNING DASHBOARD</asp:HyperLink>
               
           
          
        </div>
    <div style="height:20px;">

    </div>
	<%--Search Option--%>

           <div style="background-color: #3a5795; width: 100%; height: 40px; float: left">
                        <table style="border-collapse: separate; border-spacing: 2px; float: left; margin-left: 4px;
                            font-size: 11px; color: #FFFFFF; margin-top: 6px;">
                            <tr>
                                <td>
                                    <span class="spanText" style="color: #FFFFFF">SELECT ORDER</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrder" runat="server" CssClass="textbox" AutoPostBack="true" Width="152px" OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged">
                                      <%--  <asp:ListItem Text="--"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td width="10px">
                                </td>
                                                           
                              
                            </tr>
                        </table>
                    </div>

           <%--Search Option--%>

     <div style="height:40px;">

    </div>



    <asp:UpdatePanel ID="UpdatePanelScheduler" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
      <ContentTemplate>
        <DayPilot:DayPilotScheduler
            ID="DayPilotScheduler1"
            runat="server"
            DataStartField="eventstart"
            DataEndField="eventend"
            DataTextField="name"
            DataIdField="id"
            DataResourceField="resource_id"
            CellGroupBy="Month"
            Scale="Day"
            EventMoveHandling="CallBack"
            OnEventMove="DayPilotScheduler1_EventMove"

            ClientObjectName="dps1" 
            EventClickHandling="JavaScript"
            EventClickJavaScript="eventClick(e);"
            OnCommand="DayPilotScheduler1_Command" 
            EventEditHandling="CallBack"             
            
            OnEventClick="DayPilotScheduler1_EventClick" 
            BubbleID = "DayPilotBubble1"
			HeightSpec="Max"
            Height="480"
            >            
        </DayPilot:DayPilotScheduler>

        <DayPilot:DayPilotBubble 
            ID="DayPilotBubble1" 
            runat="server" 
            ClientObjectName="bubble" 
            OnRenderEventBubble="DayPilotBubble1_RenderEventBubble"
            Width="250"        
            Position="EventTop" >
        </DayPilot:DayPilotBubble>

      </ContentTemplate>
    </asp:UpdatePanel>

    <%--EventClickHandling="PostBack" --%>
    <%--<asp:Button ID="ButtonDummyEdit" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupEdit" runat="server" TargetControlID="ButtonDummyEdit"
      PopupControlID="PanelPopupEdit" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="PanelPopupEdit" runat="server" CssClass="modalPopup" style="display:none" Width="500px">
      <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
          <h2>Edit Line Booking</h2>
      
          <div>
              <asp:TextBox ID="TextBoxEditName" runat="server"></asp:TextBox>
          </div>

          <div>
              Line No: <br />
              <asp:DropDownList ID="DropDownEditResource" runat="server"></asp:DropDownList>
          </div>

          <div>
              Start:<br />
              <asp:TextBox ID="TextBoxEditStart" runat="server"></asp:TextBox>
          </div>

          <div>
              End:<br />
              <asp:TextBox ID="TextBoxEditEnd" runat="server"></asp:TextBox>
          </div>

          <asp:HiddenField ID="HiddenEditId" runat="server" />

          <asp:Button id="ButtonEditSave" runat="server" Text="Save" OnClick="ButtonEditSave_Click" />
          <asp:LinkButton id="ButtonEditCancel" runat="server" Text="Cancel" OnClick="ButtonEditCancel_Click" />
          </ContentTemplate>
      </asp:UpdatePanel>
    </asp:Panel>

    --%>

</asp:Content>

