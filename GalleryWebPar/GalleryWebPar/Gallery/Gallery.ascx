<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery.ascx.cs" Inherits="GalleryWebPar.VisualWebPart1.Gallery" %>

<style>
    #GalleryWebPartImageList {
        width: 100%;
        height: 175px;
        display: flex;
        float: left;
    }
    .SmallImage {
        width: auto;
        
    }
    .Image {
        width: 100px;
        height: auto;
    }
</style>

<div id="GalleryWebPart">
    <div id="GalleryWebPartBigImage"><asp:Image runat="server" CssClass="ImageActualImage"/></div>
    <div id="GalleryWebPartImageList">
        <asp:Repeater runat="server" ID="Repeater">
            <ItemTemplate>
                <div class="SmallImage"><a href='<%# "http://newpressweb:40375/" + Eval("Url") %>'></a><asp:Image runat="server" ImageUrl='<%# "http://newpressweb:40375/" + Eval("Url") %>' CssClass="Image"/></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>