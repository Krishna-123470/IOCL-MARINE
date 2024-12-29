<%@ Page Title="" Language="C#" MasterPageFile="~/WEBSITE_MASTER.Master" AutoEventWireup="true" CodeBehind="Total_Tanker_Vlcc_graph.aspx.cs" Inherits="IOCL_MARINE_NEW.Total_Tanker_Vlcc_graph" %>
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
						<h2>Total Tanker Vs VLCC</h2>
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
    <div id="chartContainer" style="height: 430px; width: 100%;"></div>
						</div>
						<div class="col-lg-3">
                            <div style="height:430px;width:100%;overflow-y:auto">
                            <asp:GridView ID="gdv_vlcc" CssClass="table table-bordered table-striped"  runat="server"></asp:GridView> 
                            </div>
                            </div>
					</div>
				</div>
				
				
			</div>
		</section>
        </section>
    
    <script>
        $(document).ready(function () {
            Total_Tanker_Vlcc()
        });
        function Total_Tanker_Vlcc() {
            $.ajax({
                type: "POST",
                url: "Total_Tanker_Vlcc_graph.aspx/Total_Tanker_Vlcc",
                data: '{}',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (r) {
                    var barColors = [];
                    for (i = 0; i < r.d.length; i++) {
                        barColors.push("#7ad2e6", "#1614bd")
                    }
                    var bar_chart_ = r.d.map(function (item) {
                        return { label: item.Year1, y: parseFloat(item.Total_Tanker)}
                    })
                    var line_chart_ = r.d.map(function (item) {
                        return { label: item.Year1, y: parseFloat(item.VLCC), indexLabel: item.VLCC }
                    })
                    CanvasJS.addColorSet("greenShades", barColors);
                    var options = {
                        colorSet: "greenShades",
                        title: {
                            text: "Total Tanker Vs VLCC"
                        },
                        //axisX: {
                        //    valueFormatString: "MMM"
                        //},
                        //axisY: {
                        //    prefix: "$",
                        //    labelFormatter: addSymbols
                        //},
                        toolTip: {
                            shared: true
                        },
                        legend: {
                            cursor: "pointer",
                            itemclick: toggleDataSeries
                        },
                        data: [
                            {
                                type: "column",
                                name: "Total Tanker",
                                showInLegend: true,
                                indexLabel: "{y}",
                                indexLabelFontColor: "#000",
                                indexLabelPlacement: "outside",
                                dataPoints: bar_chart_
                            },
                            {
                                type: "line",
                                name: "VLCC",
                                showInLegend: true,
                                lineThickness: 6,
                                markerBorderColor: "#000",
                                markerSize: 12,
                                markerBorderThickness: 2,
                                dataPoints: line_chart_
                            }
                        ]
                    };
                    $("#chartContainer").CanvasJSChart(options);
                    function toggleDataSeries(e) {
                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                            e.dataSeries.visible = false;
                        } else {
                            e.dataSeries.visible = true;
                        }
                        e.chart.render();
                    }
                }

            })
        }
</script>
</asp:Content>
