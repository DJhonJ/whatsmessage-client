<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/PublicLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Default" EnableViewState="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <section class="section">
        <h1 class="text-center">What'sMessage</h1>
        
        <div class="text-center"> 
            <p class="margin-bottom-3">
                Escanea el código QR para iniciar sesión.
            </p>

            <div class="display-flex justify-content-center flex-wrap">
                <div class="loading-qrcode width-100">
                    <h4>Loading ...</h4>
                </div>

                <img draggable="false" aria-label="Scan me" oncontextmenu="return false;" id="qrcode" class="display-none" width="300" height="300" />
            </div>
        </div>
    </section>
</asp:Content>
