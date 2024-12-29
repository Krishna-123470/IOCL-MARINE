﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WEBSITE_MASTER.Master" AutoEventWireup="true" CodeBehind="Crude_Unloaded_Monthly_graph.aspx.cs" Inherits="IOCL_MARINE_NEW.Crude_Unloaded_Monthly_graph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="js/Canvas_.js"></script>
    <style>
        .canvasjs-chart-credit{
            display:none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="wrapper">
		<section class="page_head">
			<div class="container">
				<div class="row">
					<div class="col-lg-12 col-md-12 col-sm-12">
						<h2>Crude Unloaded Monthly</h2>
					</div>
				</div>
			</div>
		</section>

        <section class="content about">
			<div class="container">
				<div class="row sub_content">
					<div class="who">
						<div class="col-lg-9">
                            <div style="width: 78px;background: #fff;height: 28px;position: absolute;left: 0;margin-top: -10px;z-index: 99;"></div>
    <div id="chartContainer" style="height: 420px; width: 100%;"></div>
                          
						</div>
						<div class="col-lg-3">
                            <div style="height:420px;width:86%;overflow-y:auto">
                            <asp:GridView ID="gdv_crd_monthly" CssClass="table table-bordered table-striped" style="width:100%"  runat="server"></asp:GridView> 
                            </div>
                            </div>
					</div>
				</div>
				
				
			</div>
		</section>
        </section>
    
<script>
    $(document).ready(function () {
        crude_onloaded_monthly()
    });
    function crude_onloaded_monthly() {
        $.ajax({
            type: "POST",
            url: "Crude_Unloaded_Monthly_graph.aspx/crude_onloaded_monthly",
            data: '{}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                var barColors = [];
                for (i = 0; i < r.d.length; i++) {
                    barColors.push("#6d0665", "#e66316")
                }
                var newArray = r.d.map(function (item) {
                    return { label: item.Month1, y: parseFloat(item.MmtMonthly) };
                });
                CanvasJS.addColorSet("greenShades",barColors);
                var options = {
                     //colorSet: "greenShades",
                    animationEnabled: true,
                    exportEnabled: true,
                    theme: "light1", // "light1", "light2", "dark1", "dark2"

                    title: {
                        text: "Crude Unloaded Monthly"
                    },
                    axisY: {
                        title: "MMT Monthly",
                        minimum: 0
                    },
                    axisX: {
                        interval: 1,
                        labelAngle: 135
                    },
                    data: [{
                        type: "column",
                        indexLabel: "{y}",
                        indexLabelFontColor: "#000",
                        indexLabelPlacement: "outside",
                        dataPoints: newArray
                    }]
                };
                $("#chartContainer").CanvasJSChart(options);
            }

        })
    }

</script>
</asp:Content>
