$(document).ready(function () {
    $("#preTotal").text(totalPrice()+" ₫");
    $("#totalCard").text(totalPrice()+" ₫");
    $(".btn-minus").on("click",  function () {
        let divContent = $(this).closest('div').closest('.cart-product-content');
        let input = divContent.find(".product-quantity").find('.inputQuanlity');
        let price = divContent.find(".product-price").find("#price");
        
        let fiPrice = price.text().replaceAll(".","") / input.val();
        if (parseInt(input.val()) - 1 > 0) {
            
            input.val(parseInt(input.val()) - 1)

        }
        
        price.text(processString(""+fiPrice * input.val()+""))
        $("#preTotal").text(totalPrice()+" ₫");
        $("#totalCard").text(totalPrice()+" ₫");
       

    })

    $(".btn-plus").on("click", function () {
        let divContent = $(this).closest('div').closest('.cart-product-content');
        let input = divContent.find(".product-quantity").find('.inputQuanlity');
        let price = divContent.find(".product-price").find("#price");
        let fiPrice = price.text().replaceAll(".","") / input.val();
        input.val(parseInt(input.val()) + 1);
        price.text(processString(""+fiPrice * input.val()+""))
        $("#preTotal").text(totalPrice()+" ₫");
        $("#totalCard").text(totalPrice()+" ₫");

    })
    
    $(".btn-delete").on("click",function(e){
        e.preventDefault();
        let divBox = $(this).closest(".card-product-item");
        divBox.remove();
        if($(".btn-delete").length <= 0){
            $(".empty-cart").css("display","block");
            $(".btn-order").attr("disable","true");
            console.log($(".btn-order"))
        }
        $("#preTotal").text(totalPrice()+" ₫");
        $("#totalCard").text(totalPrice()+" ₫");
    })

    function totalPrice(){
        let totalPrice = 0;
        
        $(".cart-product-content").map(function(){
            let priceItemEl = $(this).find(".product-price").find("#price");
            let price = priceItemEl.text().replaceAll(".","");
            totalPrice += parseInt(price);
        })
        return processString(""+totalPrice+"");
    }

    function processString(string){
        string = string.split("");
        let result=[];
        
        for(let i = string.length-1; i >= 0; i--){
            
            
            if((string.length - i) % 3 ==0 && i > 0){
                
                result += string[i] + ".";
               
            }else{
                result += string[i];
               
            }
        }
        return result.split("").reverse().join("");;
    }



})