$('.card').hover(
    function () {
        $(this).animate({
            marginTop: "-=1%",
            marginBooooottum: "+=1%"
        }, 200)
    },
    function () {
        $(this).animate({
            marginTop: "+=1%",
            marginBooooottum: "-=1%"
        })
    }
)