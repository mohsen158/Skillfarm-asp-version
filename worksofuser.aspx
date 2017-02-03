<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="masterpage.Master" CodeBehind="worksofuser.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        body {
            background-image: url("http://legacy.semantic-ui.com/images/bg.jpg");
            background-color: #cccccc;
        }
    </style>

    
     <script type="text/javascript">
  $(function() {
      $('.message .close')
    .on('click', function () {
        $(this)
          .closest('.message')
          .transition('fade')
        ;
    })
      ;
  });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   


        <div class="ui negative message" id="alert" runat="server">
            <i class="close icon"></i>
  <strong id="error" runat="server">Error</strong>
</div>


    <div class="ui container segment">


            <div class="ui piled segment">
                <h4 class="ui header">Get the works of user</h4>
                <div class="ui blue segment">
                    <label>User id :</label>
                    <div class="ui input">
                        <input placeholder="Search..." type="text" runat="server" id="inputtext" />
                    </div>
                </div>
                <asp:Button class="ui small inverted blue button" ID="Button1" runat="server" OnClick="Button2_Click" Text="Search" />
                 <asp:Button class="ui small inverted blue button" ID="Button2" runat="server" OnClick="Button1_Click" Text="All" />

                <div>
                </div>

                <div>
                    <div runat="server" id="mydiv" class="ui form">

                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <div style="padding-bottom: 10px" class="ui field stacked segments">

                                    <div class="ui red segment">
                                        <div>
                                            <asp:LinkButton ID="LinkButton1" CommandName="subject" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' UseSubmitBehavior="false" runat="server"><%#Eval("subject")%></asp:LinkButton>
                                            <a style="float: right">status</a>
                                        </div>
                                    </div>

                                    <div class="ui red segment">
                                        <p>details</p>
                                    </div>
                                    <div class="ui gray segment">
                                        <strong>remain time</strong>
                                        <asp:Button Style="float: right;" class="ui small inverted orange button" ID="btnSave" runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' UseSubmitBehavior="false" Text="Delete" />
                                    </div>
                                </div>

                            </ItemTemplate>


                        </asp:Repeater>
                    </div>


                </div>


            </div>

        </div>
   </asp:Content>

        

