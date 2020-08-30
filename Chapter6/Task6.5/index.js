import './Service.js'; 
const service = new Service();
const plusBtn = document.getElementsByClassName('plus')[0];
const modalAdd = document.getElementsByClassName('modal-add')[0];
const modalChange = document.getElementsByClassName('modal-change')[0];
const closeAddBtn = document.getElementById('close-add');
const closeChangeBtn = document.getElementById('close-change');
const addBtn = document.getElementById('add-new');
const saveBtn = document.getElementById('save');
const main = document.getElementById('main');
let nameFieldAdd = document.getElementById('name');
let contentFieldAdd = document.getElementById('content');
let nameFieldChange = document.getElementById('name-change');
let contentFieldChange = document.getElementById('content-change');

plusBtn.addEventListener("click", () => {
    modalAdd.style.display = "block";
    nameFieldAdd.value = '';
    contentFieldAdd.value = '';
}, false);

closeAddBtn.addEventListener("click", () => {
    modalAdd.style.display = "none";
}, false);

closeChangeBtn.addEventListener("click", () => {
    modalChange.style.display = "none";
}, false);

addBtn.addEventListener("click", () => {
    let name = nameFieldAdd.value,
        content = contentFieldAdd.value;
    if(name.trim() === '' && content.trim() === ''){
        console.log('Не-а, не добавлю я пустую заметку');
    }
    else{
        addNewItem(name, content);
    }
    modalAdd.style.display = "none";
});

function addNewItem(name, content){
    let id = service._id;
    service.add({'name': name, 'content': content});
    let tempMain = `<div id='item-${id}' class="item">
                    <div class="item-name">${name}</div>
                    <div class="item-content">${content}</div>
                    <button class="delete-btn"><img src="icons/delete.svg"></button>
                    </div>`;
    let newItem = document.createElement('div');
        newItem.id = `item-${id}`;
        newItem.classList.add('item');
        newItem.innerHTML = `<div class="item-name">${name}</div>
                             <div class="item-content">${content}</div>
                             <button class="delete-btn"><img src="icons/delete.svg"></button>`;
    main.insertBefore(newItem, main.childNodes[0]);

    newItem.addEventListener("click", () => {
        event.stopPropagation();
        modalChange.style.display = 'block';
        nameFieldChange.value = newItem.getElementsByClassName('item-name')[0].innerHTML;
        contentFieldChange.value = newItem.getElementsByClassName('item-content')[0].innerHTML;
        saveBtn.addEventListener("click", function changeItem(){
            event.stopPropagation();
            newItem.getElementsByClassName('item-name')[0].innerHTML = nameFieldChange.value;
            newItem.getElementsByClassName('item-content')[0].innerHTML = contentFieldChange.value;
            modalChange.style.display = 'none';
            nameFieldChange.value = '';
            contentFieldChange.value = '';
            saveBtn.removeEventListener("click", changeItem);
        }, false);
    }, false);

    newItem.getElementsByClassName('delete-btn')[0].addEventListener("click", () => {
        event.stopImmediatePropagation();
        deleteItem(newItem);
    }, false);
}


function deleteItem(htmlObject){
    let idHtml = htmlObject.id;
    let idService = idHtml.slice(idHtml.indexOf('-') + 1);

    let flag = confirm("Ты серьезно?");

    if(flag){
        service.deleteById(+idService);
        htmlObject.remove();
    }
    else{
        console.log('Удаление не подтверждено');
    }
}


