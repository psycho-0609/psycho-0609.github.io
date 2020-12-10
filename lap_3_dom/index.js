function changeColor()
{
    document.getElementById("item1").style.color = "red";
    document.getElementById("item2").style.color = "yellow";
    document.getElementById("item3").style.color = "blue";
    

}
// changeColor();
function changeBgColor()
{
     document.getElementsByTagName("body")[0].style.backgroundColor = "pink";
    
}
// changeBgColor();
function copyContent(p1,p2)
{
    
    document.getElementById(p1).textContent = document.getElementById(p2).textContent;
    
}
// copyContent("item1","item2");
function changeFrontSize(x)
{
    let els = document.querySelectorAll("#list p");
    console.log(els);
    els.forEach(element => {
        console.log(element);
        element.style.fontSize = x+"px";
    });
}
function increaseFontSize(paragraph)
{
    let el = document.getElementById(paragraph);
    let size = el.style.fontSize.split('px');
    if(size[0]  < 30)
    {
        el.style.fontSize = parseInt(size[0]) + 1 +"px";
        
    }

}
function decreaseFontSize(paragraph)
{
    let el = document.getElementById(paragraph);
    let size = el.style.fontSize.split('px');
    if(size[0]  >= 10)
    {
        el.style.fontSize = parseInt(size[0]) - 1 +"px";
        
    } 
}
// changeFrontSize(29);
// increaseFontSize("item1");
// decreaseFontSize("item1")



function numberOfLoop(arr, number)
{
    for(let i = 0; i < number; i++)
    {
        let temp = arr[0];
        for(let j = 0; j < arr.length - 1; j++)
        {
            arr[j] = arr[j + 1];
        }
        arr[arr.length -1] = temp;
    }
    return arr;
}

console.log(numberOfLoop([1,2,3,4,5,6],5));
console.log(eval("1+1*2"));