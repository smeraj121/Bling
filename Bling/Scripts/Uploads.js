function recordStats(photoId,action) {
    $.ajax({
        url: '../PhotoStats/RecordStats',
        data: { id: photoId, action: action },
        type:'POST',
        success: function (content) {
                $('#'+photoId+' #stats').html(content);
            },
        error: function (content) {
            alert("Oops! Something went wrong..");
            }
        });
    }
function Neutral(photostats) {
    if ($(photostats.children[3]).css('color') == 'rgb(0, 128, 0)') { // if already liked
        photostats.children[2].innerText = Number(photostats.children[2].innerText) - 1; //remove like
        $(photostats.children[3]).css({ 'color': 'black', 'font-weight': 'normal' }); // change color
    } else if ($(photostats.children[5]).css('color') == 'rgb(128, 0, 0)' || $(photostats.children[5]).css('color') == 'rgb(255, 0, 0)') { // if already disliked
        photostats.children[4].innerText = Number(photostats.children[4].innerText) - 1; //remove dislike
        $(photostats.children[5]).css({ 'color': 'black', 'font-weight': 'normal' }); // revert color
    } else if (photostats.children[1].classList[1] == "glyphicon-heart") { // if already hearted
        photostats.children[0].innerText = Number(photostats.children[0].innerText) - 1; // unheart
        $(photostats.children[1]).removeClass("glyphicon-heart").addClass("glyphicon-heart-empty"); //
    }
}
$(document).ready(
    $('.glyphicon').click(function() {
        var action;
        if (this.classList[1] == "glyphicon-heart-empty") {
            action = "H";
            Neutral(this.parentElement);
            $(this).siblings()[0].innerText = Number($(this).siblings()[0].innerText) + 1;
            $(this).addClass("glyphicon-heart").removeClass("glyphicon-heart-empty");
        } else if (this.classList[1] == "glyphicon-heart") {
            action = "H";
            Neutral(this.parentElement);
        }
        else if (this.classList[1] == "glyphicon-thumbs-up") {
            if ($(this).css('color') == 'rgb(0, 0, 0)' || $(this).css('color') == 'rgb(51, 51, 51)') {
                Neutral(this.parentElement);
                $(this).siblings()[2].innerText = Number($(this).siblings()[2].innerText) + 1;
                $(this).css({ 'color': 'green', 'font-weight': 'bold' })
            } else { Neutral(this.parentElement) }
            action = "L";
        }
        else if (this.classList[1] == "glyphicon-thumbs-down") {
            if ($(this).css('color') == 'rgb(0, 0, 0)' || $(this).css('color') == 'rgb(51, 51, 51)') {
                Neutral(this.parentElement)
                $(this).siblings()[4].innerText = Number($(this).siblings()[4].innerText) + 1;
                $(this).css({ 'color': 'red', 'font-weight': 'bold' });

            } else { Neutral(this.parentElement) }
            action = "D";
        }
        recordStats(this.parentElement.parentElement.id, action);
        console.log(this.parentElement.id);
    })
);

//$(document).on('click', ".glyphicon", function () {
//    $('.glyphicon').click(function () {
//        var action;
//        if (this.classList[1] == "glyphicon-heart-empty") {
//            action = "H";
//            Neutral(this.parentElement);
//            $(this).siblings()[0].innerText = Number($(this).siblings()[0].innerText) + 1;
//            $(this).addClass("glyphicon-heart").removeClass("glyphicon-heart-empty");
//        } else if (this.classList[1] == "glyphicon-heart") {
//            action = "H";
//            Neutral(this.parentElement);
//        }
//        else if (this.classList[1] == "glyphicon-thumbs-up") {
//            if ($(this).css('color') == 'rgb(0, 0, 0)' || $(this).css('color') == 'rgb(51, 51, 51)') {
//                Neutral(this.parentElement);
//                $(this).siblings()[2].innerText = Number($(this).siblings()[2].innerText) + 1;
//                $(this).css({ 'color': 'green', 'font-weight': 'bold' })
//            } else { Neutral(this.parentElement) }
//            action = "L";
//        }
//        else if (this.classList[1] == "glyphicon-thumbs-down") {
//            if ($(this).css('color') == 'rgb(0, 0, 0)' || $(this).css('color') == 'rgb(51, 51, 51)') {
//                Neutral(this.parentElement)
//                $(this).siblings()[4].innerText = Number($(this).siblings()[4].innerText) + 1;
//                $(this).css({ 'color': 'red', 'font-weight': 'bold' });

//            } else { Neutral(this.parentElement) }
//            action = "D";
//        }
//        recordStats(this.parentElement.parentElement.id, action);
//        console.log(this.parentElement.id);
//    });
//    return false;
//});


