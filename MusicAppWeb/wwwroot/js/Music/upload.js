var idForm = "#formUpload"

$(document).ready(function() {    
    $("#music").change(getInfoMusic)

    $("#btnSubmit").click(validateSubmit)
})

var durationMusic = 0
async function getInfoMusic() {
    const mp3file = $(this)[0].files[0]
    const reader = new FileReader()

    reader.readAsArrayBuffer(mp3file)
    reader.onload = function() {
        const audioContext = new (window.AudioContext || window.webkitAudioContext)()
        audioContext.decodeAudioData(reader.result,
            function(buffer) {
                durationMusic = buffer.duration
            }
        )
    };
    
    reader.onerror = function() {
        console.log(reader.error);
    };  
}

function validateSubmit() {
    const values = getValues()

    const validated = validateValues(values)

    if (validated) {
        const inputs = getInputsHiddens(values)
        addInputsForm(inputs)
        $(idForm).submit();
    } else {
        alert('Complete the form.')
    }
}

function getValues() {
    let values = {}
   
    const music  = createItem('Name', getNameMusic($("#music").val()))
    const lyric  = createItem('Lyrics',$("#lyric").val())
    const time   = createItem('Time',  Math.ceil(durationMusic))
    const artist = createItem('Artist', $("#artist").val())
    const album  = createItem('Album', $("#album").val())

    values[music['name']]  = music['value']
    values[lyric['name']]  = lyric['value']
    values[time['name']]   = time['value']
    values[artist['name']] = artist['value']
    values[album['name']]  = album['value']

    return values;
}

function createItem(name, value) {
    return { name : name, value: value }
}

function validateValues(values) {
    for (const key in values) {
        if (key != "Album" && (values[key] == null || values[key] == ""))
            return false
    }

    return true
}

function getInputsHiddens(values) {
    const names = ["Name", "Lyrics", "Time", "Artist", "Album"]

    let inputs = []
    names.forEach(n => {
        inputs.push(createInputHidden(n, values[n]))
    })

    return inputs 
}

function createInputHidden(name, value) {
    return `<input type="hidden" name="${name}" value="${value}"></input>`
}

function addInputsForm(inputs) {
    inputs.forEach(i => {
        $(idForm).append(i)
    })
}

function getNameMusic(music) {
    if (music == "") return music 

    music = music.replace(/^.*[\\\/]/, '')
    const index = music.indexOf(".mp3")

    if (index != -1)
        return music.substring(0, index)

    return music  
}

