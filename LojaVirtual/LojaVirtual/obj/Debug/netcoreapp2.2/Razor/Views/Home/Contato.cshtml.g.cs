#pragma checksum "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b9b1008e4d9de1a20d96b61efd42575b7b766f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contato), @"mvc.1.0.view", @"/Views/Home/Contato.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Contato.cshtml", typeof(AspNetCore.Views_Home_Contato))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b9b1008e4d9de1a20d96b61efd42575b7b766f4", @"/Views/Home/Contato.cshtml")]
    public class Views_Home_Contato : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
  
    // Layout = "_Layout";
    ViewData["Title"] = "Contato";

#line default
#line hidden
            BeginContext(71, 1468, true);
            WriteLiteral(@"
    <main role=""main"">
        <br />
        <br />
        <div class=""container"">
            <div class=""row"">
                <aside class=""col-md-6"">
                    <h4 class=""subtitle-doc"">
                        # Outros contatos
                        <a href=""#"" data-html=""code_desc_simple"" class=""showcode"">[code]</a>
                    </h4>
                    <div id=""code_desc_simple"">
                        <div class=""box"">
                            <dl>
                                <dt>Devolução/Garantia: </dt>
                                <dd>devolucao@lojavirtual.com.br</dd>
                            </dl>
                            <dl>
                                <dt>Televendas: </dt>
                                <dd>(61) 4000-2000</dd>
                            </dl>
                            <dl>
                                <dt>SAC:</dt>
                                <dd>sac@lojavirtual.com.br</dd>
                           ");
            WriteLiteral(@" </dl>
                        </div> <!-- box.// -->
                    </div> <!-- code-wrap.// -->
                </aside>
                <aside class=""col-sm-6"">

                    <h4 class=""subtitle-doc"">
                        # Contato
                       
                    </h4>
                    <div>

                        <article class=""card"">
                            <div class=""card-body p-5"">
");
            EndContext();
#line 43 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
                                 if (ViewData["MSG_S"] != null)
                                {

#line default
#line hidden
            BeginContext(1639, 67, true);
            WriteLiteral("                                    <p class=\"alert alert-success\">");
            EndContext();
            BeginContext(1707, 17, false);
#line 45 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
                                                              Write(ViewData["MSG_S"]);

#line default
#line hidden
            EndContext();
            BeginContext(1724, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 46 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
                                }

#line default
#line hidden
            BeginContext(1765, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 48 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
                                 if (ViewData["MSG_E"] != null)
                                {

#line default
#line hidden
            BeginContext(1867, 66, true);
            WriteLiteral("                                    <p class=\"alert alert-danger\">");
            EndContext();
            BeginContext(1934, 27, false);
#line 50 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
                                                             Write(Html.Raw(ViewData["MSG_E"]));

#line default
#line hidden
            EndContext();
            BeginContext(1961, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 51 "C:\Users\ifeme\source\ASP.netCoreMVCLojaVirtual\LojaVirtual\LojaVirtual\Views\Home\Contato.cshtml"
                                }

#line default
#line hidden
            BeginContext(2002, 2720, true);
            WriteLiteral(@"
                                <form role=""form"" method=""post"" action=""/Home/ContatoAcao"">
                                    <div class=""form-group"">
                                        <label for=""name"">Nome</label>
                                        <div class=""input-group"">
                                            <div class=""input-group-prepend"">
                                                <span class=""input-group-text""><i class=""fa fa-user""></i></span>
                                            </div>
                                            <input type=""text"" class=""form-control"" id=""name"" name=""name"" placeholder=""""
                                                   required="""">
                                        </div> <!-- input-group.// -->
                                    </div> <!-- form-group.// -->

                                    <div class=""form-group"">
                                        <label for=""email"">E-mail</label>
                  ");
            WriteLiteral(@"                      <div class=""input-group"">
                                            <div class=""input-group-prepend"">
                                                <span class=""input-group-text""><i class=""fa fa-at""></i></span>
                                            </div>
                                            <input type=""text"" class=""form-control"" id=""email"" name=""email"" placeholder="""">
                                        </div> <!-- input-group.// -->
                                    </div> <!-- form-group.// -->

                                    <div class=""row"">
                                        <div class=""col-sm-12"">
                                            <div class=""form-group"">
                                                <label for=""texto""><span class=""hidden-xs"">Texto</span> </label>
                                                <div class=""form-inline"">
                                                    <textarea class=""form-control"" name");
            WriteLiteral(@"=""texto"" id=""texto"" style=""width:100%""></textarea>

                                                </div>
                                            </div>
                                        </div>
                                    </div> <!-- row.// -->
                                    <button class=""subscribe btn btn-primary btn-block"" type=""submit""> Enviar </button>
                                </form>
                            </div> <!-- card-body.// -->
                        </article> <!-- card.// -->

                    </div> <!-- code-wrap.// -->

                </aside>
            </div>
        </div>

    </main>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
