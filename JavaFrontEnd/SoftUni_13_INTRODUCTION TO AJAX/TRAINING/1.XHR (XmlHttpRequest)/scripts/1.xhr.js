function loadRepos() {
    // TODO

    console.log("loadRepos");

    let req = new XMLHttpRequest();

    req.onreadystatechange = function(){

        console.log("onreadystatechange, this.readyState = " + this.readyState + ", this.status = " + this.status);
        console.log("onreadystatechange, this.responseText = " + this.responseText);

        if(this.readyState == 4 && this.status == 200){
            document.getElementById('res').textContent =
                this.responseText;
        }
    };

    req.open("GET", "https://api.github.com/users/testnakov/repos", true);

    req.send();

}