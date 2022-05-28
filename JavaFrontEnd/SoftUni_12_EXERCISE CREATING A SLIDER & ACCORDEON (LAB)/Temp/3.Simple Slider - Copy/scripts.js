function MyCallSlick() {
    $(".regular").slick({
        dots: true,
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3
    });

    console.log("MyCallSlick Executed!");
}