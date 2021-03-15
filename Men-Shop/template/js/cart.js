$(document).ready(function(){
    $(".btn-minus").on("click",function(){
        let input = $(this).closest('div').find(".inputQuanlity")
        if(parseInt(input.val())-1 > 0) {
            input.val(parseInt(input.val()) -1)
        }
      
    })

    $(".btn-plus").on("click",function(){
        let input = $(this).closest('div').find(".inputQuanlity")
        input.val(parseInt(input.val()) +1)
    })

    
})