import { useEffect, useState } from "react"
import { Form, FormGroup } from "reactstrap"
import { getEmotions } from "../../managers/emotionManager";
import { fetchJournalsByEmotion } from "../../managers/journalManager";

export const FilterJournalsByEmotion = ({journals, setJournals, getMyJournals}) => {

    const [emotions, setEmotions] = useState([]);
    const [selectedEmotion, setSelectedEmotion] = useState(null);


    useEffect(() => {
        getEmotions().then(setEmotions);
    },[])

    const handleSelect = (e) => {
        const value = parseInt(e.target.value);
        setSelectedEmotion(value);
        if (value === 0) {
            getMyJournals();
        }
    };

    useEffect(() => {
        if (selectedEmotion !== null && selectedEmotion !== 0)
        {
            fetchJournalsByEmotion(selectedEmotion).then(setJournals);
        } 
    },[selectedEmotion])

    console.log("selected emotion", selectedEmotion)
    
    console.log(journals)

    if (!journals){
        return null;
    }

    return (
        <>
        <Form>
            <FormGroup>
            <select onChange={handleSelect}>
                <option value="0">Filter Journals By Emotion</option>
                {emotions.map(e => <option key={e.id} value={e.id}>{e.emotionName}</option>)}
            </select>
            </FormGroup>
        </Form>
        </>
    )

}