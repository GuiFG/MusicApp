$(document).ready(function() {
    $("#add").click(addMusicList)

    $("#btnSubmit").click(validateAndSubmit)
})

function addMusicList() {
    const selected = $("#selectMusics option:selected")
    const list = $("#musics")
    const music = createItemMusic(selected)
    music.addTrashItem()

    list.append(music["item"])
}

function createItemMusic(musicJquery) {
    const li = document.createElement("li")

    li.id = musicJquery.val()
    li.classList.add("list-group-item")
    li.innerText = musicJquery.text()
    
    return { item: li, addTrashItem : addTrashItem }  
}

function addTrashItem() {
    const item = this.item

    const span = document.createElement("span")
    span.classList.add("ml-2")
    span.onclick = removeItem

    const icon = document.createElement('i')
    icon.classList.add("fas")
    icon.classList.add("fa-trash")
    icon.style.cursor = "pointer"

    span.append(icon)
    item.append(span)
}

function removeItem() {
    const item = this.parentElement

    item.remove()
}

function validateAndSubmit() {
    const name = $("#name").val()

    if (name != "") {
        $("#formPlaylist").submit()
    }

}
