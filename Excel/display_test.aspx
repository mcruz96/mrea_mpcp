<%@ Page Language="C#" AutoEventWireup="true" CodeFile="display.aspx.cs" Inherits="app_display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <!-- Required meta tags -->
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

        <!-- Meta -->
        <meta name="description" content="MARTINREA - Indicador de eficiencia">
        <meta name="author" content="Luis Torres + mx.luistorres@gmail.com">
        <meta http-equiv="refresh" content="30; url=http://192.168.13.235/displays/app/display.aspx?clave=P1&mesa=OV102">

        <title>MARTINREA - Indicador de eficiencia</title>

        <!-- vendor css -->
        <link href="../lib/font-awesome/css/font-awesome.css" rel="stylesheet">
        <link href="../lib/Ionicons/css/ionicons.css" rel="stylesheet">

        <!-- Bracket CSS -->
        <link rel="stylesheet" href="../css/bracket.css">
        <style>
            body {
                color: #000000 !important;
            }
            .dev-page{visibility: hidden;}

            .flotante{
            	position: absolute;
            	float: left;
            	height: 30px;
            	width: 95%;
            }

            .w40{
            	background: gray;
            	color: white;
            	padding-right: 3px;
            	padding-left: 3px;
            	line-height: 25px;
            	height: 25px;
            }

            .arigth{
            	text-align: right;
            }

            .w20{
            	width: 20%;
            	min-width: 20%;
            	max-width: 20%;
            }
            .parpadea {
				  animation-name: parpadeo;
				  animation-duration: 2s;
				  animation-timing-function: linear;
				  animation-iteration-count: infinite;

				  -webkit-animation-name:parpadeo;
				  -webkit-animation-duration: 2s;
				  -webkit-animation-timing-function: linear;
				  -webkit-animation-iteration-count: infinite;
			}

				@-moz-keyframes parpadeo{  
				  0% { opacity: 1.0; }
				  50% { opacity: 0.0; }
				  100% { opacity: 1.0; }
				}

				@-webkit-keyframes parpadeo {  
				  0% { opacity: 1.0; }
				  50% { opacity: 0.0; }
				   100% { opacity: 1.0; }
				}

				@keyframes parpadeo {  
				  0% { opacity: 1.0; }
				   50% { opacity: 0.0; }
				  100% { opacity: 1.0; }
				}
				body{
					height: 5000px;
				}
        </style>
</head>
<body class="br-simple-white">
    <!-- ########## START: HEAD PANEL ########## -->
    <div class="br-header-display">
        <div class="mg-l-30">
            <image src="../images/logo.png" class="img-fluid wd-50" />
            <h2 class="float-right mg-l-230" id="h2titulo" runat="server"></h2>
        </div>
    </div><!-- br-header -->
    <!-- ########## END: HEAD PANEL ########## -->

    <!-- ########## START: MAIN PANEL ########## -->
    <div class="br-mainpanel-display" id="mainpanel">
        <div class="row">
            <div class="col-3 text-center"><h4><b>No PARTE</b></h4></div>
            <div class="col-3 text-center"><h4><b>PLANEADO</b></h4></div>
            <div class="col-3 text-center"><h4><b>REPORTADO</b></h4></div>
            <div class="col-3 text-center"><h4><b>EFICIENCIA</b></h4></div>
        </div>

        <div id="DisplayDiv" runat="server"></div>

    </div>

    <!-- ########## END: MAIN PANEL ########## -->
        <div class="row">
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            
            </div>
        </form>
    </div>
</body>
</html>
