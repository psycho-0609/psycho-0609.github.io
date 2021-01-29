$(document).ready(function () {

    ////////////////// active fixed navbar /////////////////
    $(window).scroll(function () {
        console.log('1')

        var winTop = $(window).scrollTop();
        if (winTop > 30) {
            $("#navbarFixed").addClass("navbar-fixed")
        } else {
            $("#navbarFixed").removeClass("navbar-fixed")
        }
    })

    //////////// hide active nav left /////////////////
    $("#btn-active-nav").click(function () {
        $("#hideContent").addClass("hide-content");
        $("#navbar-active").addClass("active-nav");
    })

    $("#hideContent").click(function () {
        $("#hideContent").removeClass("hide-content");
        $("#navbar-active").removeClass("active-nav");
    })

    $("#btnDropdownMenuProduct").click(function () {
        $("#dropdownMenuProduct").sliceToogle();
    })




    ////Search///////

    $("#btnSearch").click(function(){
        $("#hideContentSearch").addClass("hide-content-search");
        $("#searchBox").addClass("search-active");
        console.log("abc");
    })


    $("#hideContentSearch").click(function () {
        $("#hideContentSearch").removeClass("hide-content-search");
        $("#searchBox").removeClass("search-active");
    })



    $(".btnCancel").click(function(){
        $("#hideContentSearch").removeClass("hide-content-search");
        $("#searchBox").removeClass("search-active");
    })

    $("#btnSearchNav").click(function(){
        var classList = document.getElementById('navSearchBox').className;
        if(classList.includes("nav-search-box-active"))
        {
            $(".nav-search-box").removeClass("nav-search-box-active");
        }else{
            $(".nav-search-box").addClass("nav-search-box-active");
        }
    })



    /////////////////  Creat calender ///////////////////////

    /////// Day //////////
    function createDay(maxDay) {
        var elementSelect = $("#formSigninSlectDay");
        for (let i = 1; i <= maxDay; i++) {
            var elOption = $("<option></option>").text(i);
            elOption.attr("value", i);
            elementSelect.append(elOption);
        }
    }

    //////// Month ////////
    function createMonth(maxDay) {
        var elementSelect = $("#formSigninSlectMonth");
        for (let i = 1; i <= 12; i++) {
            var elOption = $("<option></option>").text(i);
            elOption.attr("value", i);
            elementSelect.append(elOption);
        }
    }

    //////// Year ////////
    function createYear(minYear) {
        var date = new Date();
        var currentYear = date.getFullYear();
        var elementSelect = $("#formSigninSlectYear");
        for (let i = minYear; i <= currentYear; i++) {
            var elOption = $("<option></option>").text(i);
            elOption.attr("value", i);
            elementSelect.append(elOption);
        }
    }

    createDay(31);
    createMonth();
    createYear(1920);





})