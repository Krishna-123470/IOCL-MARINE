<%@ Page Title="" Language="C#" MasterPageFile="~/WEBSITE_MASTER.Master" AutoEventWireup="true" CodeBehind="Tanker_Milestone_graph.aspx.cs" Inherits="IOCL_MARINE_NEW.Tanker_Milestone_graph" %>
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
						<h2>Tanker Milestone</h2>
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
    <div id="chartContainer" style="height: 430px; width: 100%;"></div>
						</div>
						<div class="col-lg-4">
                            <div style="height:430px;width:100%;overflow-y:auto">
                            <asp:GridView ID="gdv_Tanker_Milestone" AutoGenerateColumns="false" CssClass="table table-bordered table-striped"  runat="server">
                                 <Columns>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tanker Number">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTanker_no" runat="server" Text='<%# Eval("TankerNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                            </asp:GridView> 
                            </div>
                            </div>
					</div>
				</div>
				
				
			</div>
		</section>
        </section>
    
<script>
    $(document).ready(function () {
        tanker_milestone()
    });
    function tanker_milestone() {
        $.ajax({
            type: "POST",
            url: "Tanker_Milestone_graph.aspx/tanker_milestone",
            data: '{}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (r) {
              
                var newArray = r.d.map(function (item) {
                    return { label: convert_date(item.Date1), y: parseFloat(item.TankerNumber) };
                });
               
                var options = {
                    animationEnabled: true,
                    exportEnabled: true,
                    theme: "light1", // "light1", "light2", "dark1", "dark2"

                    title: {
                        text: "Tanker Milestone"
                    },
                    axisY: {
                        title: "Tanker Number",
                        minimum: 0
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

    function convert_date(date1)
    {
        var value = new Date
             (
                  parseInt(date1.replace(/(^.*\()|([+-].*$)/g, ''))
             );
        var dts = moment(new Date(value)).format('DD-MMM-YYYY');
        return dts;
    }

</script>
</asp:Content>
