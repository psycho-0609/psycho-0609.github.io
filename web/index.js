$(document).ready(function()
{
    let click = true;
    let btn = document.querySelectorAll("#btn");
    let animate = document.querySelectorAll("#animation");
    console.log(animate);
    console.log(btn);
    $(btn).map(function(index,el){

        $(el).click(function(){
            let inew ="fa fa-chevron-up";
            let iold = "fa fa-chevron-down";
            
            // if($(animate).eq(index).css("display")){
            //     $(animate).eq(index).hide(1000);
            //     $(el).find("i").attr("class",iold);
            // }
            // else{
            //     $(animate).eq(index).show(1000);
            //     $(el).find("i").attr("class",inew);
            // }
            $(animate).eq(index).slideToggle(1000);

            // console.log(height)
        })
    })

    // $("#btn").click(function(){
    //     $("#animation").toggle(1000);
    // })
    
})
