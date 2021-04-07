$(document).ready(function(){
    $("#owlCarouselLogo").owlCarousel({
        autoplay:true,
        autoplayTimeout:3000,
        loop: true,
        margin: 10,
        nav: false,
        dots: false,
        responsive: {
            0: {
                items: 2
            },
            480:{
                item:3
            },
            600: {
                items: 4
            },
            1000: {
                items: 6
            }
        }
    })

})