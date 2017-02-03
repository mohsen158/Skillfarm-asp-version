<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="masterpage.Master" CodeBehind="insert_works.aspx.cs" Inherits="WebApplication1.insert_works" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    

    <div id="nav" runat="server" class="ui error message">
        <i class="close icon"></i>
        <div id="alert" runat="server" class="header">
        </div>

    </div>
    <div class="ui  piled container segment">
      

            <div class="ui form">
                <div class="inline fields">
                    <div class="four wide field">
                        <label>Work</label>
                        <input placeholder="Subject" id="subject" runat="server" type="text">
                    </div>
                    <div class="three wide field">
                        <input placeholder="Status" id="status" runat="server" type="text">
                    </div>

                </div>
                <div class="field">
                    <label>Details</label>
                    <textarea id="details" runat="server"></textarea>
                </div>
                <div class="field">
                    <label>User name</label>
                    <select class="ui fluid search dropdown" id="user_id" runat="server" name="card[expire-month]">
                    </select>
                </div>

                <div class="field">
                    <label>course name</label>
                    <select class="ui fluid search dropdown" runat="server" id="course_id" name="card[expire-month]">
                    </select>
                </div>
                <div class="field">
                    <label>Dead time</label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </div>
                <asp:Button class="ui primary basic button" ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />

            </div>
        
    </div>
    

</asp:Content>