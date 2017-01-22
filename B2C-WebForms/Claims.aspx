<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Claims.aspx.cs" Inherits="B2C_WebForms.Claims" %>
<asp:Content ID="ClaimsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Claims</h2>

    <h4>Claims Present in the Claims Identity: <%=DisplayName%></h4>

    <table class="table table-bordered">
        <tr>
            <th class="claim-type claim-data claim-head">Claim Type</th>
            <th class="claim-data claim-head">Claim Value</th>
        </tr>

        <% if(Request.IsAuthenticated) { foreach (System.Security.Claims.Claim claim in System.Security.Claims.ClaimsPrincipal.Current.Claims)
                {%>
            <tr>
                <td class="claim-type claim-data"><%: claim.Type %></td>
                <td class="claim-data"><%:claim.Value %></td>
            </tr>
        <% }
        }%>
    </table>
</asp:Content>
