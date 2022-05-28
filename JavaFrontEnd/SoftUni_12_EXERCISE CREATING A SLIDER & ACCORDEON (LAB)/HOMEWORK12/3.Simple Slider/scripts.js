function MyCallSlick() {
    $(".autoplay").slick({
        dots: true,
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000
    });

    console.log("MyCallSlick Executed!");
}