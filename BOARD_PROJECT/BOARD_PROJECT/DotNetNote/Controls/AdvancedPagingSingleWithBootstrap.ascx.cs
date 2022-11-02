using System;
using System.ComponentModel;

namespace BOARD_PROJECT.DotNetNote.Controls {
    public partial class AdvancedPagingSingleWithBootstrap : System.Web.UI.UserControl {

        // 공통 속성 : 검색 모드: 검색모드이면 true, 그렇지 않으면 false
        public bool SearchMode { get; set; } = false;
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        /// <summary>
        /// 몇 번째 페이지를 보여줄 건지 : 웹 폼에서 속성으로 전달됨
        /// </summary>
        [Category("페이징처리")] // Category 특성은 모두 생략 가능 (속성에 표시됨)
        public int PageIndex { get; set; }

        /// <summary>
        /// 총 몇개의 페이지가 만들어지는지 : 총 레코드 수 / 10
        /// </summary>
        [Category("페이징처리")] // Category 특성은 모두 생략 가능 (속성에 표시됨)
        public int PageCount { get; set; }

        /// <summary>
        /// 페이지 사이즈 : 한 페이지에 몇 개의 레코드를 보여줄 건지 결정
        /// </summary>
        [Category("페이징처리")]
        [Description("한 페이지에 몇 개의 레코드를 보여줄 건지 결정")]
        public int PageSize { get; set; } = 10; // 기본값 10

        /// <summary>
        /// 레코드 카운트 : 현재 테이블에 몇 개의 레코드가 있는지 지정
        /// </summary>
        public int _RecordCount;

        [Category("페이징처리")]
        [Description("현재 테이블에 몇 개의 레코드가 있는지 지정")]
        public int RecordCount {
            get { return _RecordCount; }
            set {
                _RecordCount = value;
                PageCount = ((_RecordCount - 1) / PageSize) + 1;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

            SearchMode = (!string.IsNullOrEmpty(Request.QueryString["SearchField"]) && !string.IsNullOrEmpty(Request.QueryString["SearchQuery"]));

            if (SearchMode) {
                SearchField = Request.QueryString["SearchField"];
                SearchQuery = Request.QueryString["SearchQuery"];
            }
            ++PageIndex;
            int i = 0;

            string strPage = "<ul class='pagination pagination-sm'>";
            if (PageIndex>10) {
                if (SearchMode) {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?Page="
                        + Convert.ToString(((PageIndex - 1) / (int)10) * 10)
                        + "&SearchField=" + SearchField
                        + "&SearchQuery=" + SearchQuery + "\">◀</a></li>";
                }
                else {
                    strPage += "<li><a href =\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?Page="
                        + Convert.ToString(((PageIndex - 1) / (int)10) * 10)
                        + "\">◀</a></li>";
                }
            }
            else {
                if (PageIndex!=1) {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        + "?Page="
                        + Convert.ToString(PageIndex-1)
                        + "\">◀</a></li>";

                }
                else {
                    strPage += "<li class=\"disabled\"><a>◁</a></li>";

                }
            }
            //가운데, 숫자 형식의 페이저 표시
            for (i = (((PageIndex-1)/(int)10)*10+1); 
                 i <= ((((PageIndex - 1) / (int)10)+1)*10); 
                 i++) 
            {
                if (i>PageCount) {
                    break;  //있는 페이지까지만 페이저 링크 출력
                }
                if (i == PageIndex) {
                    strPage += "<li class = 'active'><a href=#>"
                                + i.ToString() + "</a></li>";
                }
                else {
                    if (SearchMode) {
                        strPage += "<li><a href=\""
                            + Request.ServerVariables["SCRIPT_NAME"]
                            + "?Page=" + i.ToString()
                            + "&SearchField=" + SearchField
                            + "%SearchQuery=" + SearchQuery + "\">"
                            + i.ToString() + "</a></li>";
                    }
                    else {
                        strPage += "<li><a href=\""
                            + Request.ServerVariables["SCRIPT_NAME"]
                            + "?Page=" + i.ToString() + "\">"
                            + i.ToString() + "</a></li>";
                    }
                }
            }

            // 다음 10개 링크
            if (i <= PageCount) //  다음 10개 링크가 있다면, ...
            {
                if (SearchMode) {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        //+ "?BoardName=" + Request["BoardName"]
                        + "?Page="
                        + Convert.ToString(((PageIndex - 1) / (int)10) * 10 + 11)
                        + "&SearchField=" + SearchField
                        + "&SearchQuery=" + SearchQuery + "\">▶</a></li>";
                }
                else {
                    strPage += "<li><a href=\""
                        + Request.ServerVariables["SCRIPT_NAME"]
                        //+ "?BoardName=" + Request["BoardName"]
                        + "?Page="
                        + Convert.ToString(PageIndex + 1)
                        //+ Convert.ToString(((PageIndex - 1) / (int)10) * 10 + 11)
                        + "\">▶</a></li>";
                }
            }
            else {
                strPage += "<li class=\"disabled\"><a>▷</a></li>";
            }
            // <!--이전 10개, 다음 10개 페이징 처리 종료-->
            strPage += "</ul>";


            ctlAdvancedPagingWithBootstrap.Text = strPage;
        }
    }
}