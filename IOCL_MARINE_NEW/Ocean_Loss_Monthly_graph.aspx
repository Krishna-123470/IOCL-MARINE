<%@ Page Title="" Language="C#" MasterPageFile="~/WEBSITE_MASTER.Master" AutoEventWireup="true" CodeBehind="Ocean_Loss_Monthly_graph.aspx.cs" Inherits="IOCL_MARINE_NEW.Ocean_Loss_Monthly_graph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/chart_min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="wrapper">
		<section class="page_head">
			<div class="container">
				<div class="row">
					<div class="col-lg-12 col-md-12 col-sm-12">
						<h2>Ocean Loss</h2>
					</div>
				</div>
			</div>
		</section>

        <section class="content about">
			<div class="container">
				<div class="row sub_content">
					<div class="who">
						<div class="col-lg-8">
    <canvas id="myChart" style="width:100%"></canvas>
						</div>
						<div class="col-lg-4">
                            <div style="height:430px;width:100%;overflow-y:auto">
                            <asp:GridView ID="gdv_ocean_loss_monthly" CssClass="table table-bordered table-striped"  runat="server"></asp:GridView> 
                            </div>
                            </div>
					</div>
				</div>
				
				
			</div>
		</section>
        </section>
 

<script>
    $(document).ready(function () {
        ocean_loss_monthly()
    });
    function ocean_loss_monthly() {
        $.ajax({
            type: "POST",
            url: "Ocean_Loss_Monthly_graph.aspx/ocean_loss_monthly",
            data: '{}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                var xaxis_ = []
                var yaxis_ = []
                var barColors = [];
                for (i = 0; i < r.d.length; i++) {
                    xaxis_.push(r.d[i].Month1)
                    yaxis_.push(r.d[i].KlPercentage)
                    barColors.push("blue")
                }
                var xValues = xaxis_;
                var yValues = yaxis_;
                var title = "KI Percentage"
                var myoption = {
                    
                        scales: {
                            yAxes: [{
                                ticks: {
                                    fontSize: 15
                                }
                            }],
                            xAxes: [{
                    ticks: {
                    fontSize: 15
                }
                            }],
                          
                        },

                    legend: {
                        display: true,
                        //text: title,
                        position:"bottom"
                    },
                    title: {
                        display: true,
                        //text: "Ocean Loss"
                    },
                    tooltips: {
                        enabled: true
                    },
                    hover: {
                        animationDuration: 1
                    },
                    animation: {
                        duration: 1,
                        onComplete: function () {
                            var chartInstance = this.chart,
                                ctx = chartInstance.ctx;
                            //ctx.font = this.scale.font;

                            ctx.textAlign = 'center';
                            ctx.fillStyle = "#fff";
                            ctx.font = "bold 15px 'Helvetica Neue', Helvetica, Arial, sans-serif";
                            ctx.textBaseline = 'bottom';
                            // Loop through each data in the datasets
                            this.data.datasets.forEach(function (dataset, i) {
                                var meta = chartInstance.controller.getDatasetMeta(i);
                                meta.data.forEach(function (bar, index) {
                                    var data = dataset.data[index];
                                    ctx.fillText(data, bar._model.x, bar._model.y - 5);
                                });
                            });
                        }
                    }
                };


                var ctx = document.getElementById('myChart').getContext('2d');


                new Chart("myChart", {
                    type: "bar",
                    data: {
                        labels: xValues,
                        datasets: [{
                            label: title,
                            backgroundColor: barColors,
                            data: yValues
                        }]
                    },
                    options: myoption,
                });
               

            }

        })
    }

</script>
</asp:Content>
