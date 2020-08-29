$(document).ready(function()
{
    let click = true;
    let btn = document.querySelectorAll("#btn");
    let animate = document.querySelectorAll("#animation");
    console.log(animate);
    console.log(btn);
    $(btn).map(function(index,el){

        $(el).click(function(){
            let height = $(animate).eq(index).css("height");
            height = height.replace("px","00");
            let inew ="fa fa-chevron-up";
            let iold = "fa fa-chevron-down";
            if(height>0){
                $(animate).eq(index).css("height","0");
                $(el).find("i").attr("class",iold);
            }
            else{
                $(animate).eq(index).css("height","100%");
                $(el).find("i").attr("class",inew);
            }

            console.log(height)
        })
    })
    
})
