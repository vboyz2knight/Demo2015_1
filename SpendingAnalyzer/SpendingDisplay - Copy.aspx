<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpendingDisplay.aspx.cs" Inherits="Demo2015_1.SpendingAnalyzer.SpendingAnyalyzerDisplay" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
        <div class="container">
         <nav class="navbar navbar-default" role="navigation">
         <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
              <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-2">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="#">Spending Analyzer</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-left" id="bs-example-navbar-collapse-2">
              <ul class="nav navbar-nav">
                <li class="active">
                    <!-- Button trigger modal for test-->
                    <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
                      Test
                    </button>

                   <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                      <div class="modal-dialog">
                        <div class="modal-content">
                          <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="myModalLabel">We'd Love to Hear From You</h3>
                          </div>
                          <div class="modal-body">
                            <form class="form-horizontal col-sm-12">
                              <div class="form-group"><label>Name</label><input class="form-control required" placeholder="Your name" data-placement="top" data-trigger="manual" data-content="Must be at least 3 characters long, and must only contain letters." type="text"></div>
                              <div class="form-group"><label>Message</label><textarea class="form-control" placeholder="Your message here.." data-placement="top" data-trigger="manual"></textarea></div>
                              <div class="form-group"><label>E-Mail</label><input class="form-control email" placeholder="email@you.com (so that we can contact you)" data-placement="top" data-trigger="manual" data-content="Must be a valid e-mail address (user@gmail.com)" type="text"></div>
                              <div class="form-group"><label>Phone</label><input class="form-control phone" placeholder="999-999-9999" data-placement="top" data-trigger="manual" data-content="Must be a valid phone number (999-999-9999)" type="text"></div>
                              <div class="form-group"><button type="submit" class="btn btn-success pull-right">Send It!</button> <p class="help-block pull-left text-danger hide" id="form-error">&nbsp; The form is not valid. </p></div>
                            </form>
                          </div>
                          <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>
                          </div>
                        </div>
                      </div>
                    </div>
                </li>
                <li class="active"><button class="navbar-button btn-info btn">Latest 3 mo.</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Latest 6 mo.</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Current Year</button></li>
                <li class="active"><button class="navbar-button btn-info btn">Date Range</button></li>
                <li class="active">
                    <!-- Button trigger modal for upload files-->
                    <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#uploadModal">
                      Add Data
                    </button>

                    <!-- Upload Modal -->
                    <div class="modal fade" id="uploadModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                      <div class="modal-dialog">
                        <div class="modal-content">
                          <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="myModalLabel">Upload your files.</h4>
                          </div>
                          <form>
                          <div class="modal-body">
                            <p>Only files with extension *.csv are allowed.</p>
                            <p><asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"></asp:FileUpload></p>
                            
                          </div>
                          <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" id="btn">Save changes</button>
                          </form>
                          </div>
                        </div>
                      </div>
                    </div>
                        <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
	                    <script>
	                        // Fallback to loading jQuery from a local path if the CDN is unavailable
	                        (window.jQuery || document.write('<script src="/scripts/jquery-1.9.0.min.js"><\/script>'));
	                    </script>
	                    <script>
	                        /* form validation plugin */
	                        $.fn.goValidate = function () {
	                            var $form = this,
                                    $inputs = $form.find('input:text');

	                            var validators = {
	                                name: {
	                                    regex: /^[A-Za-z]{3,}$/
	                                },
	                                pass: {
	                                    regex: /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/
	                                },
	                                email: {
	                                    regex: /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/
	                                },
	                                phone: {
	                                    regex: /^[2-9]\d{2}-\d{3}-\d{4}$/,
	                                }
	                            };
	                            var validate = function (klass, value) {
	                                var isValid = true,
                                        error = '';

	                                if (!value && /required/.test(klass)) {
	                                    error = 'This field is required';
	                                    isValid = false;
	                                } else {
	                                    klass = klass.split(/\s/);
	                                    $.each(klass, function (i, k) {
	                                        if (validators[k]) {
	                                            if (value && !validators[k].regex.test(value)) {
	                                                isValid = false;
	                                                error = validators[k].error;
	                                            }
	                                        }
	                                    });
	                                }
	                                return {
	                                    isValid: isValid,
	                                    error: error
	                                }
	                            };
	                            var showError = function ($input) {
	                                var klass = $input.attr('class'),
                                        value = $input.val(),
                                        test = validate(klass, value);

	                                $input.removeClass('invalid');
	                                $('#form-error').addClass('hide');

	                                if (!test.isValid) {
	                                    $input.addClass('invalid');

	                                    if (typeof $input.data("shown") == "undefined" || $input.data("shown") == false) {
	                                        $input.popover('show');
	                                    }

	                                }
	                                else {
	                                    $input.popover('hide');
	                                }
	                            };

	                            $inputs.keyup(function () {
	                                showError($(this));
	                            });

	                            $inputs.on('shown.bs.popover', function () {
	                                $(this).data("shown", true);
	                            });

	                            $inputs.on('hidden.bs.popover', function () {
	                                $(this).data("shown", false);
	                            });

	                            $form.submit(function (e) {

	                                $inputs.each(function () { /* test each input */
	                                    if ($(this).is('.required') || $(this).hasClass('invalid')) {
	                                        showError($(this));
	                                    }
	                                });
	                                if ($form.find('input.invalid').length) { /* form is not valid */
	                                    e.preventDefault();
	                                    $('#form-error').toggleClass('hide');
	                                }
	                            });
	                            return this;
	                        };
	                        $('form').goValidate();


	                    </script>
                </li>
              </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
        </div>
        <hr />
     <div class="container">
        <div class="row">
            <div class="col-md-6">
                <button class="navbar-button btn-info btn">Reset</button>
                    <asp:Chart ID="Chart1" runat="server" Height="300px" BackImageAlignment="Center" Width="300px"  OnClick="Chart1_Click">
                        <Series>
                            <asp:Series ChartType="Pie" Name="Series1" Legend="Legend1" >
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Area3DStyle Enable3D="True" />
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Alignment="TopLeft" Name="Title1" Text="Spending by Category">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>
            </div>
            <div class="col-md-6">
                <div class="container">
                    <div class="container-fluid"><h3>Datas from A to B.</h3></div><br />
                        <div class="container-fluid">Total spendings: 123.</div><br />
                        <div class="container-fluid">Total income: 123.</div><br />

                        <div class="container-fluid">Top 3 Spending categories:</div>
                        <ul>
                            <li>1</li>
                            <li>2</li>
                            <li>3</li>
                         </ul>
                </div>               
            </div>
        </div>
    </div>
        <hr /><a href="#" class="btn btn-primary btn-sm active" role="button">Primary link</a>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True"></asp:GridView>
            </div>
            <div class="col-md-6">
                <div class="container">
                    <div class="container-fluid"><h3>Datas from A to B.</h3></div><br />
                        <div class="container-fluid">Total spendings: 123.</div><br />
                        <div class="container-fluid">Total income: 123.</div><br />

                        <div class="container-fluid">Top 3 Spending categories:</div>
                        <ul>
                            <li>1</li>
                            <li>2</li>
                            <li>3</li>
                         </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
   
</asp:Content>
