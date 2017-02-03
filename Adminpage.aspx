<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Adminpage.aspx.cs" Inherits="WebApplication1.Adminpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="ui container segment">
    <div class="ui cards">
        <asp:repeater ID="worksrepeat" OnItemCommand="ApOrDecCommand" runat="server">
            
             
            <ItemTemplate>
                
                
               
  <div class="card">
    <div class="content">
      
      <div class="header">
        <%#Eval("subject") %>
      </div>
      <div class="meta">
        Friends of Veronika
      </div>
      <div class="description">
        Elliot requested permission to view your contact details
      </div>
    </div>
    <div class="extra content">
      <div class="ui two buttons">
        <asp:LinkButton id="btApprove" commandname="Approve" runat="server" class="ui basic green button" CommandArgument='<%# Eval("id") %>' UseSubmitBehavior="false">Approve</asp:LinkButton>
        <asp:LinkButton id="btDecline" commandname="Decline" runat="server" class="ui basic red button" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' UseSubmitBehavior="false">Decline</asp:LinkButton>
      </div>
    </div>
  </div>
                   
               
            </ItemTemplate>
             

        </asp:repeater>
</div>
    </div>
</asp:Content>
