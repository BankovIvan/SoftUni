function timer() {
    // TODO

    //Global timer variable
    let gTimer;

    //Attach START button script;
    $('#start-timer').on("click", function () {
        //console.log("start-timer");
        if(gTimer === undefined) {
            gTimer = setInterval(step, 1000);
        }
    });

    //Attach STOP button script;
    $('#stop-timer').on("click", function () {
        //console.log("stop-timer");
        clearInterval(gTimer);
        gTimer = undefined;
    });

    //Timing function

    function step(){

        var nHours = Number($('#hours').text());
        var nMinutes = Number($('#minutes').text());
        var nSeconds = Number($('#seconds').text());

        nSeconds = nSeconds + 1;

        if(nSeconds > 59){
            nMinutes = nMinutes + 1;
            nSeconds = 0;
        }
        if(nMinutes > 59){
            nHours = nHours + 1;
            nMinutes = 0;
        }
        if(nHours > 23){
            nHours = 0;
        }

        if(nHours < 10){
            $('#hours').text("0" + nHours);
        }else{
            $('#hours').text(nHours);
        }
        if(nMinutes < 10){
            $('#minutes').text("0" + nMinutes);
        }else{
            $('#minutes').text(nMinutes);
        }
        if(nSeconds < 10){
            $('#seconds').text("0" + nSeconds);
        }else{
            $('#seconds').text(nSeconds);
        }

        //console.log("step");

        return;
    }
}
