function recordStats(photoId,action) {
    $.ajax({
        url: '../PhotoStats/RecordStats',
        data: { id: photoId, action: action },
        type: 'POST',
        dataType: 'JSON',
        success: function (content) {
            if (content.Success) {
                setStats(photoId, content);
            }
            //$('#' + photoId + ' #stats').children()[0];
        },
        error: function (content) {
            alert("Oops! Something went wrong..");
            }
        });
}
function setStats(photoid, stat) {
    $('#' + photoid + ' #stats').children()[0].innerHTML = stat.Loves;
    $('#' + photoid + ' #stats').children()[2].innerHTML = stat.Likes;
    $('#' + photoid + ' #stats').children()[4].innerHTML = stat.Dislikes;
    changeIcons(photoid,stat.Stat);
    console.log($('#' + photoid + ' #stats').children()[0]);
}
function changeIcons(photoid,Stat) {
    $($('#' + photoid + ' #stats').children()[1]).removeClass('glyphicon-heart').addClass('glyphicon-heart-empty');
    $($('#' + photoid + ' #stats').children()[3]).removeClass('liked');
    $($('#' + photoid + ' #stats').children()[5]).removeClass('disliked');
    if (Stat == "H") {
        $($('#' + photoid + ' #stats').children()[1]).addClass('glyphicon-heart').removeClass('glyphicon-heart-empty');
    }
    else if (Stat == "L") {
        $($('#' + photoid + ' #stats').children()[3]).addClass('liked');
    } else if (Stat == "D") {
        $($('#' + photoid + ' #stats').children()[5]).addClass('disliked');
    }
}
function Neutral(photostats) {
    if ($(photostats.children[3]).hasClass('liked')) { // if already liked
        photostats.children[2].innerText = Number(photostats.children[2].innerText) - 1; //remove like
        $(photostats.children[3]).removeClass('liked'); // change color
    } else if ($(photostats.children[5]).hasClass('disliked')) { // if already disliked
        photostats.children[4].innerText = Number(photostats.children[4].innerText) - 1; //remove dislike
        $(photostats.children[5]).removeClass('disliked'); // revert color
    } else if ($(photostats.children[1]).hasClass("glyphicon-heart")) { // if already hearted
        photostats.children[0].innerText = Number(photostats.children[0].innerText) - 1; // unheart
        $(photostats.children[1]).removeClass("glyphicon-heart").addClass("glyphicon-heart-empty"); //
    }
}
$(document).ready(
    $('.glyphicon').click(function() {
        var action;
        if ($(this).hasClass('glyphicon-heart-empty') || $(this).hasClass('glyphicon-heart') ) {
            action = "H";
            Neutral(this.parentElement);
            $(this).siblings()[0].innerText = Number($(this).siblings()[0].innerText) + 1;
            $(this).addClass("glyphicon-heart").removeClass("glyphicon-heart-empty");
        } else if (this.classList[1] == "glyphicon-heart") {
            action = "H";
            Neutral(this.parentElement);
        }
        else if ($(this).hasClass("glyphicon-thumbs-up")) {
            if (!$(this).hasClass('liked')) {
                Neutral(this.parentElement);
                $(this).siblings()[2].innerText = Number($(this).siblings()[2].innerText) + 1;
                $(this).addClass("liked");
            } else { Neutral(this.parentElement) }
            action = "L";
        }
        else if ($(this).hasClass("glyphicon-thumbs-down")) {
            if ($(this).hasClass("disliked")) {
                Neutral(this.parentElement)
                $(this).siblings()[4].innerText = Number($(this).siblings()[4].innerText) + 1;
                $(this).addClass('disliked');

            } else { Neutral(this.parentElement) }
            action = "D";
        }
        recordStats(this.parentElement.parentElement.id, action);
        console.log(this.parentElement.id);
    })
);


