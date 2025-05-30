(function($) {
   "use strict"


 var dlabChartlist = function(){
	
	var screenWidth = $(window).width();

	var flotBar1 = function(){
		$.plot("#flotBar1", [{
			data: [[0, 3], [2, 8], [4, 5], [6, 13], [8, 5], [10, 8], [12, 4], [14, 6]]
		}], {
			series: {
				bars: {
					show: true,
					lineWidth: 0,
					fillColor: '#0d99ff'
				}
			},
			grid: {
				borderWidth: 1,
				borderColor: 'transparent'
			},
			yaxis: {
				tickColor: 'transparent',
				font: {
					color: '#858282',
					size: 10
				}
			},
			xaxis: {
				tickColor: 'transparent',
				font: {
					color: '#858282',
					size: 10
				}
			}
		});
	}
	
	var flotBar2 = function(){
		$.plot("#flotBar2", [{
			data: [[0, 3], [2, 8], [4, 5], [6, 13], [8, 5], [10, 8], [12, 8], [14, 10]],
			bars: {
				show: true,
				lineWidth: 0,
				fillColor: '#0d99ff'
			}
		}, {
			data: [[1, 5], [3, 8], [5, 10], [8, 8], [9, 9], [11, 5], [13, 4], [15, 6]],
			bars: {
				show: true,
				lineWidth: 0,
				fillColor: '#ffaa2b'
			}
		}], 
		{
			grid: {
				borderWidth: 1,
				borderColor: 'transparent'
			},
			yaxis: {
				tickColor: 'transparent',
				font: {
					color: '#858282',
					size: 10
				}
			},
			xaxis: {
				tickColor: 'transparent',
				font: {
					color: '#858282',
					size: 10
				}
			}
		});
	}
	
	var flotLine1 = function(){
		var newCust = [[0, 2], [1, 3], [2, 6], [3, 5], [4, 8], [5, 8], [6, 10]];
		var retCust = [[0, 1], [1, 2], [2, 5], [3, 3], [4, 5], [5, 6], [6, 9]];

		var plot = $.plot($('#flotLine1'), [
			{
				data: newCust,
				label: 'New Customer',
				color: '#0d99ff'
			},
			{
				data: retCust,
				label: 'Returning Customer',
				color: '#ffaa2b'
			}
		],
		{
			series: {
				lines: {
					show: true,
					lineWidth: 1
				},
				shadowSize: 0
			},
			points: {
				show: false,
			},
			legend: {
				noColumns: 1,
				position: 'nw'
			},
			grid: {
				hoverable: true,
				clickable: true,
				borderColor: '#ddd',
				borderWidth: 0,
				labelMargin: 5,
				backgroundColor: 'transparent'
			},
			yaxis: {
				min: 0,
				max: 15,
				color: 'transparent',
				font: {
					size: 10,
					color: '#999'
				}
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#999'
				}
			}
		});
	}
	
	var flotLine2 = function(){
		var newCust = [[0, 2], [1, 3], [2, 6], [3, 5], [4, 8], [5, 8], [6, 10]];
		var retCust = [[0, 1], [1, 2], [2, 5], [3, 3], [4, 5], [5, 6], [6, 9]];
		
		var plot = $.plot($('#flotLine2'), [
			{
				data: newCust,
				label: 'New Customer',
				color: '#0d99ff'
			},
			{
				data: retCust,
				label: 'Returning Customer',
				color: '#ffaa2b'
			}
		],
		{
			series: {
				lines: {
					show: false
				},
				splines: {
					show: true,
					tension: 0.4,
					lineWidth: 1,
					//fill: 0.4
				},
				shadowSize: 0
			},
			points: {
				show: false,
			},
			legend: {
				noColumns: 1,
				position: 'nw'
			},
			grid: {
				hoverable: true,
				clickable: true,
				borderColor: '#ddd',
				borderWidth: 0,
				labelMargin: 5,
				backgroundColor: 'transparent'
			},
			yaxis: {
				min: 0,
				max: 15,
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			}
		});		
	}
	
	var flotLine3 = function(){
		var newCust2 = [[0, 10], [1, 8], [2, 8], [3, 9], [4, 6], [5, 5], [6, 8]];
		var retCust2 = [[0, 8], [1, 5], [2, 6], [3, 8], [4, 4], [5, 3], [6, 6]];
		
		var plot = $.plot($('#flotLine3'), [
			{
				data: newCust2,
				label: 'New Customer',
				color: '#0d99ff'
			},
			{
				data: retCust2,
				label: 'Returning Customer',
				color: '#ffaa2b'
			}
		],
		{
			series: {
				lines: {
					show: true,
					lineWidth: 1
				},
				shadowSize: 0
			},
			points: {
				show: true,
			},
			legend: {
				noColumns: 1,
				position: 'nw'
			},
			grid: {
				hoverable: true,
				clickable: true,
				borderColor: '#ddd',
				borderWidth: 0,
				labelMargin: 5,
				backgroundColor: 'transparent'
			},
			yaxis: {
				min: 0,
				max: 15,
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			}
		});
	}
	
	var flotArea1 = function(){
		var newCust = [[0, 2], [1, 3], [2, 6], [3, 5], [4, 8], [5, 8], [6, 10]];
		var retCust = [[0, 1], [1, 2], [2, 5], [3, 3], [4, 5], [5, 6], [6, 9]];
		
		var plot = $.plot($('#flotArea1'), [
			{
				data: newCust,
				label: 'New Customer',
				color: '#0d99ff'
			},
			{
				data: retCust,
				label: 'Returning Customer',
				color: '#ffaa2b'
			}
		],
		{
			series: {
				lines: {
					show: true,
					lineWidth: 0,
					fill: 1
				},
				shadowSize: 0
			},
			points: {
				show: false,
			},
			legend: {
				noColumns: 1,
				position: 'nw'
			},
			grid: {
				hoverable: true,
				clickable: true,
				borderColor: '#ddd',
				borderWidth: 0,
				labelMargin: 5,
				backgroundColor: 'transparent'
			},
			yaxis: {
				min: 0,
				max: 15,
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			}
		});
	}
	
	var flotArea2 = function(){
		var newCust = [[0, 2], [1, 3], [2, 6], [3, 5], [4, 8], [5, 8], [6, 10]];
		var retCust = [[0, 1], [1, 2], [2, 5], [3, 3], [4, 5], [5, 6], [6, 9]];
		
		var plot = $.plot($('#flotArea2'), [
			{
				data: newCust,
				label: 'New Customer',
				color: '#0d99ff'
			},
			{
				data: retCust,
				label: 'Returning Customer',
				color: '#ffaa2b'
			}
		],
		{
			series: {
				lines: {
					show: false
				},
				splines: {
					show: true,
					tension: 0.4,
					lineWidth: 0,
					fill: 1
				},
				shadowSize: 0
			},
			points: {
				show: false,
			},
			legend: {
				noColumns: 1,
				position: 'nw'
			},
			grid: {
				hoverable: true,
				clickable: true,
				borderColor: '#ddd',
				borderWidth: 0,
				labelMargin: 5,
				backgroundColor: 'transparent'
			},
			yaxis: {
				min: 0,
				max: 15,
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			}
		});
	}
	
	var flotLine4 = function(){
		var previousPoint = null;

		$('#flotLine4, #flotLine4').bind('plothover', function (event, pos, item) {
			$('#x').text(pos.x.toFixed(2));
			$('#y').text(pos.y.toFixed(2));

			if (item) {
				if (previousPoint != item.dataIndex) {
					previousPoint = item.dataIndex;

					$('#tooltip').remove();
					var x = item.datapoint[0].toFixed(2),
						y = item.datapoint[1].toFixed(2);

					showTooltip(item.pageX, item.pageY, item.series.label + ' of ' + x + ' = ' + y);
				}
			} else {

				$('#tooltip').remove();
				previousPoint = null;
			}
		});
		$('#flotLine4, #flotLine4').bind('plotclick', function (event, pos, item) {
			if (item) {
				plot.highlight(item.series, item.datapoint);
			}
		});
	}

	function showTooltip(x, y, contents) {
		$('<div id="tooltip" class="tooltipflot">' + contents + '</div>').css({
			position: 'absolute',
			display: 'none',
			top: y + 5,
			left: x + 5
		}).appendTo('body').fadeIn(200);
	}

	var flotRealtime1 = function(){
		/*********** REAL TIME UPDATES **************/

		var data = [], totalPoints = 50;

		function getRandomData() {
			if (data.length > 0)
				data = data.slice(1);
			while (data.length < totalPoints) {
				var prev = data.length > 0 ? data[data.length - 1] : 50,
					y = prev + Math.random() * 10 - 5;
				if (y < 0) {
					y = 0;
				} else if (y > 100) {
					y = 100;
				}
				data.push(y);
			}
			var res = [];
			for (var i = 0; i < data.length; ++i) {
				res.push([i, data[i]])
			}
			return res;
		}


		// Set up the control widget
		var updateInterval = 1000;

		var plot4 = $.plot('#flotRealtime1', [getRandomData()], {
			colors: ['#0d99ff'],
			series: {
				lines: {
					show: true,
					lineWidth: 1
				},
				shadowSize: 0	// Drawing is faster without shadows
			},
			grid: {
				borderColor: 'transparent',
				borderWidth: 1,
				labelMargin: 5
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			},
			yaxis: {
				min: 0,
				max: 100,
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			}
		});
		update_plot4();
		function update_plot4() {
			plot4.setData([getRandomData()]);
			plot4.draw();
			setTimeout(update_plot4, updateInterval);
		}
	}
	
	var flotRealtime2 = function(){
		var data = [], totalPoints = 50;

		function getRandomData() {
			if (data.length > 0)
				data = data.slice(1);
			while (data.length < totalPoints) {
				var prev = data.length > 0 ? data[data.length - 1] : 50,
					y = prev + Math.random() * 10 - 5;
				if (y < 0) {
					y = 0;
				} else if (y > 100) {
					y = 100;
				}
				data.push(y);
			}
			var res = [];
			for (var i = 0; i < data.length; ++i) {
				res.push([i, data[i]])
			}
			return res;
		}
		
		// Set up the control widget
		var updateInterval = 1000;
		
		var plot5 = $.plot('#flotRealtime2', [getRandomData()], {
			colors: ['#0d99ff'],
			series: {
				lines: {
					show: true,
					lineWidth: 0,
					fill: 0.9
				},
				shadowSize: 0	// Drawing is faster without shadows
			},
			grid: {
				borderColor: 'transparent',
				borderWidth: 1,
				labelMargin: 5
			},
			xaxis: {
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			},
			yaxis: {
				min: 0,
				max: 100,
				color: 'transparent',
				font: {
					size: 10,
					color: '#858282'
				}
			}
		});

		

		
		update_plot5();
		function update_plot5() {
			plot5.setData([getRandomData()]);
			plot5.draw();
			setTimeout(update_plot5, updateInterval);
		}
	}
	$(function() {

		var d1 = [];
		for (var i = 0; i <= 10; i += 1) {
			d1.push([i, parseInt(Math.random() * 30)]);
		}

		var d2 = [];
		for (var i = 0; i <= 10; i += 1) {
			d2.push([i, parseInt(Math.random() * 30)]);
		}

		var d3 = [];
		for (var i = 0; i <= 10; i += 1) {
			d3.push([i, parseInt(Math.random() * 30)]);
		}

		var stack = 0,
			bars = true,
			lines = false,
			steps = false;

		function plotWithOptions() {
			$.plot("#flotRealtime3", [ d1, d2, d3 ], {
				series: {
					stack: stack,
					
					size: 11,
					lineHeight: 13,
					style: "italic",
					weight: "bold",
					family: "sans-serif",
					variant: "small-caps",
					color: "var(--primary)",

					lines: {
						show: false,
						fill: false,
						steps: steps
					},
					bars: {
						show: bars,
						lineWidth: 0,
						barWidth: 0.6
						
					},
					
				},grid: {
				borderWidth: 1,
				borderColor: 'transparent'
			},
                yaxis: {
                    tickColor: 'transparent',
					
                },
				xaxis:{
					tickColor:'transparent',
					
					
				}
			});
		}

		plotWithOptions();

		$(".stackControls button").click(function (e) {
			e.preventDefault();
			stack = $(this).text() == "With stacking" ? true : null;
			plotWithOptions();
		});

		$(".graphControls button").click(function (e) {
			e.preventDefault();
			bars = $(this).text().indexOf("Bars") != -1;
			lines = $(this).text().indexOf("Lines") != -1;
			steps = $(this).text().indexOf("steps") != -1;
			plotWithOptions();
		});

		// Add the Flot version string to the footer

		$("#footer").prepend("Flot " + $.plot.version + " &ndash; ");
	});
	

	
	/* Function ============ */
	return {
		init:function(){
		},
		
		
		load:function(){
			flotBar1();	
			flotBar2();
			flotLine1();	
			flotLine2();	
			flotLine3();		
			flotArea1();
			flotArea2();
			flotLine4();
			flotRealtime1();
			flotRealtime2();
			
			
		},
		
		resize:function(){
		}
	}

}();

jQuery(document).ready(function(){
});
	
jQuery(window).on('load',function(){
	dlabChartlist.load();
});

jQuery(window).on('resize',function(){
	dlabChartlist.resize();
});     

})(jQuery);