function loadRepos() {
    // AJAX call …

    $('#repos').empty();

    var url = `https://api.github.com/users/${$('#username').val()}/repos`;

    //let promise =
    $.ajax({url, success: displayRepos, error: displayError});

    //promise.then((data) => {console.log(data);});

    function displayRepos(respos) {
        for (let repo of respos) {
            let link = $('<a>').text(repo.full_name);
            link.attr('href', repo.html_url);
            $("#repos").append($('<li>').append(link));
        }
    }
    function displayError(err) {
        $("#repos").append($("<li>Error</li>"));
    }

}
