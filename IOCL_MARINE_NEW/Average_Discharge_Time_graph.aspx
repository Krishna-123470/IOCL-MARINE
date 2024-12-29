<%@ Page Title="" Language="C#" MasterPageFile="~/WEBSITE_MASTER.Master" AutoEventWireup="true" CodeBehind="Average_Discharge_Time_graph.aspx.cs" Inherits="IOCL_MARINE_NEW.Average_Discharge_Time_graph" %>
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
						<h2>Average Discharge Time</h2>
					</div>
				</div>
			</div>
		</section>

        <section class="content about">
			<div class="container">
				<div class="row sub_content">
					<div class="who">
						<div class="col-lg-8">
                            <div style="width: 78px;background: #fff;height: 28px;position: absolute;left: 0;margin-top: -10px;z-index: 99;"></div>
    <div id="chartContainer" style="height: 450px; width: 100%;"></div>
						</div>
						<div class="col-lg-4">
                            <div style="height:450px;width:90%;overflow-y:auto">
                            <asp:GridView ID="gdv_avg_dis_time" CssClass="table table-bordered table-striped" style="width:100%"  runat="server"></asp:GridView> 
                            </div>
                            </div>
					</div>
				</div>
				
				
			</div>
		</section>
        </section>
    

<script>
    $(document).ready(function () {
        Avg_dis_time()
    });
    function Avg_dis_time() {
        $.ajax({
            type: "POST",
            url: "Average_Discharge_Time_graph.aspx/Avg_dis_time",
            data: '{}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                var newArray = r.d.map(function (item) {
                    return { label: item.Year1, y: parseFloat(item.TurnArroundTime) }
                })
               var newArray1 = r.d.map(function (item) {
                    return { label: item.Year1, y: parseFloat(item.TankerNumber) }
                })
			    var y1_array = [];
                var y_array = [];
                for (i = 0; i < r.d.length; i++) {
                    y1_array.push(r.d[i].TankerNumber)
                    y_array.push(r.d[i].TurnArroundTime)
                }
                
                var y_max_TurnArroundTime = Math.max.apply(Math, y_array) + 30
                var y1_max_TankerNumber = Math.max.apply(Math, y1_array) + 30

                var options = {
                    exportEnabled: true,
                    animationEnabled: true,
                    title: {
                        text: "Average Discharge Time"
                    },
                    //subtitles: [{
                    //    text: "Click Legend to Hide or Unhide Data Series"
                    //}],
                    //axisX: {
                    //    title: "States"
                    //},
                    axisY: {
                        title: "Turn Arround Time",
                        titleFontColor: "#4F81BC",
                        lineColor: "#4F81BC",
                        labelFontColor: "#4F81BC",
                        tickColor: "#4F81BC",
						maximum: y_max_TurnArroundTime 
                    },
                    axisY2: {
                        title: "Tanker Number",
                        titleFontColor: "#C0504E",
                        lineColor: "#C0504E",
                        labelFontColor: "#C0504E",
                        tickColor: "#C0504E",
						maximum: y1_max_TankerNumber 
                    },
                    toolTip: {
                        shared: true
                    },
                    legend: {
                        cursor: "pointer",
                        itemclick: toggleDataSeries
                    },
					axisX:{
		                interval: 1,
						labelAngle: 135
	                  },
                    data: [{
                        type: "spline",
                        name: "Turn Arround Time",
                        borderWidth: 6,
                        showInLegend: true,
                        lineThickness: 4,
                        markerBorderColor: "#000",
                        markerSize: 9,
                        markerBorderThickness: 1,
                        dataPoints: newArray
                    },
                    {
                        type: "spline",
                        name: "Tanker Number",
                        axisYType: "secondary",
                        showInLegend: true,
                        markerBorderColor: "#000",
                        markerSize: 9,
                        markerBorderThickness: 1,
                        lineThickness: 4,
                        dataPoints: newArray1
                    }]
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
