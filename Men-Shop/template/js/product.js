$(document).ready(function(){
    let arrayEUl = $(".list-cate")
    console.log(arrayEUl);
    let count = 0;
    let arrayBtn = document.querySelectorAll(".btn-active-filter-box");
    let allFilterBox = $(".filter-box #filterCate")
    console.log(allFilterBox);
    console.log(arrayBtn);

    arrayBtn.forEach(function(element,index){
        element.addEventListener("click",function(){
            console.log(element.textContent);
            if(element.textContent == "+"){
                
                allFilterBox.eq(index).slideDown();
                element.textContent="-";
            }else if(element.textContent == "-"){
                allFilterBox.eq(index).slideUp();
                element.textContent="+";
            }
        })
    })


    // Filter box active
    $("#btnActiveFilter").click(function(){
        $("#hideContent").addClass("display-bg-behind-filter");
        $("#optionFilterBox").addClass("filter-box-all-active");
    })
    $("#hideContent").click(function () {
        $("#hideContent").removeClass("display-bg-behind-filter");
        $("#optionFilterBox").removeClass("filter-box-all-active");
    })
})