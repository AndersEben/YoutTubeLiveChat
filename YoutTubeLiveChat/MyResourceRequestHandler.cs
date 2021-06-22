using CefSharp;
using System;

namespace YoutTubeLiveChat
{
    public class MyResourceRequestHandler : IResourceRequestHandler
    {
        public string videoID;

        void IDisposable.Dispose()
        {

        }

        ICookieAccessFilter IResourceRequestHandler.GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            return null;
        }

        IResourceHandler IResourceRequestHandler.GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            return null;
        }

        IResponseFilter IResourceRequestHandler.GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            MyResponseFilter _filter = new MyResponseFilter();
            _filter.videoID = videoID;
            var _return = _filter;
            return _return;
        }

        CefReturnValue IResourceRequestHandler.OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            return CefReturnValue.Continue;
        }

        bool IResourceRequestHandler.OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            return false;
        }

        void IResourceRequestHandler.OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {

        }

        void IResourceRequestHandler.OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {

        }

        bool IResourceRequestHandler.OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            return false;
        }
    }

}
