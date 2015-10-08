(function ($) {

    $(document).ready(function () {

        $(".tab_content").hide();
        $(".tab_content:first").show();

        $("ul.tabs li").click(function () {

            $("ul.tabs li").removeClass("active");

            $(this).addClass("active");

            var activeTab = $(this).attr("rel");

            var evaluationId = getParameterByName('evaluationId');
            var perspectiveId = null;
            var url = '/Evaluation/GetEvaluationContent/';
            var editMode = false;

            switch (activeTab) {
                case "tab1":
                    perspectiveId = 2
                    break;
                case "tab2":
                    perspectiveId = 3
                    break;
                case "tab3":
                    perspectiveId = 4
                    break;
                default:
                    perspectiveId = 2
            }
            
            if ($("#EditMode").val() == "true")
                editMode = true;
            else
                editMode = false;
                
            LoadEvaluationByPerspective(evaluationId, perspectiveId, url, editMode);

            $("#" + activeTab).fadeIn();
            
        });
    });

    function LoadEvaluationByPerspective(evaluationId, perspectiveId, url, editMode) {
        $.ajax({
            url: url,
            data: {
                evaluationId: evaluationId,
                perspectiveId: perspectiveId,
                editMode: editMode
            },
            success: function (data) {
                var activeTab = $(this).attr("rel");

                $(".tab_content").html(data);
            }
        });
    }

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

})(jQuery);
