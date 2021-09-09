<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Pie.ascx.vb" Inherits="controles_Pie" %>
<div id="footer-wrapper">
            
<section id="footer" class="container">

    <div class="row">

        <div class="span8">

            <div class="first-col theme-selector">
<%--                <h4>Themes</h4>
<div class="content">
<select class="store-theme-list noskin" id="themeName" name="themeName">
    <option value="BetaDark">Beta Dark</option>
    <option value="Beta">Beta</option>
    <option value="Zeta">Zeta</option>
    <option selected="selected" value="Alpha">Alpha</option>
    <option value="AlphaBlue">Alpha Blue</option>
    <option value="AlphaBlack">Alpha Black</option>
</select>
</div>--%>
            </div>
        </div>

        <div class="span8">
            <div class="x-first-col">
                <div class="row-fluid">
                    <nav class="footer-quicklinks service span12 first-col">
                        <h4>Service</h4>
                        <ul class="unstyled">
                            <li><a href="">Shipping & Returns</a></li>
                        </ul>
                    </nav>

                    <nav class="footer-quicklinks company span12 first-col">
                        <h4>Company</h4>
                        <ul class="unstyled">
                            <li><a href="">Blog</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>

        <div class="span8">
                <div class="footer-newsletter last-col">
                    <h4>Subscribe to newsletters</h4>

                    <div id="newsletter-subscribe-block">

						<div class="input-append input-block-level">
							<input id="newsletter-email" name="NewsletterEmail" placeholder="Email" type="text" value="" />
							<button id="newsletter-subscribe-button" class="btn btn-success">Submit</button>
						</div>

                        <label class="radio inline">
							<input type="radio" id="newsletter-subscribe" value="newsletter-subscribe" name="optionsRadios" checked="checked"> 
							Subscribe
                        </label>
                        <label class="radio inline">
							<input type="radio" id="newsletter-unsubscribe" value="newsletter-unsubscribe" name="optionsRadios"> 
							Unsubscribe
                        </label>

						<span class="field-validation-valid" data-valmsg-for="NewsletterEmail" data-valmsg-replace="true"></span>
                    
                    </div>
                    <div id="newsletter-result-block" class="alert alert-success hide"></div>
                </div>
        </div>

    </div>

    <div class="row">
        <div class="span24">
            
        </div>
    </div>
</section>

<div class="footer-disclaimer container">
    <div class="row">
		<div class="span8">
				<div class="footer-legal">
					* Todos los precios incluyen IVA<%-- <a href="" >shipping</a>--%>
				</div>
		</div>

		<div class="span8 ac">
			<a href="" class='sm-hint' target='_blank'><strong>Old Sport</strong></a> 
		</div>

		<div class="span8 ar">
			<div>
				Copyright &copy; 2016 Old Sport. Todos los derechos reservados.
			</div>
		</div>
	</div>
</div>



        </div>