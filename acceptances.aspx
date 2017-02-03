<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="acceptances.aspx.cs" Inherits="WebApplication1.acceptances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ui container segment">
        <div class="ui olive inverted segment">Acceptances</div>
        <asp:Repeater ID="acceptancesList" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="ItemBound">
            <SeparatorTemplate>
                <div class="ui clearing divider"></div>
            </SeparatorTemplate>

            <ItemTemplate>
                <div class="ui divided items">
                    <div class="item">
                        <div class="image">
                             <%  var seed = Math.Abs((int)DateTime.Now.Ticks);

                                        Random sd = new Random();
                                        for (int i = 0; i < 100; i++)
                                        {
                                            sd.Next(1, 25);
                                        }
                                        int ran = sd.Next(1, 25);
                                        randd++;
                                        //var asd = "<img  src='image/" + Convert.ToString(ran)+".png'"+">"; 
                                        int a = randd + seed;
                                        a = a % 24;
                                        a++;
                                        var asd = "<img  src='image/" + a + ".png'" + ">";

                                    %>

                                    <%=asd%>
                           
                        </div>
                        <div class="content">
                            <a class="header"><%#Eval("y.name")%></a>
                            <div class="meta">
                                <span class="cinema"><%#Eval("i.detail")%></span>
                            </div>
                            <div class="description">
                                <p></p>
                            </div>
                            <div class="extra">
                                <asp:Repeater ID="ChildRepeater" OnItemCommand="course_ItemCommand" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandName="course" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' UseSubmitBehavior="false" runat="server"  class="ui label"><%#Eval("name")%></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="ui right floated  button">
                                    <asp:LinkButton ID="LinkButton1" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "i.id") %>' UseSubmitBehavior="false" runat="server">Delete </asp:LinkButton>
                                           
          <i class="right chevron icon"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>


        </asp:Repeater>








    </div>
</asp:Content>
