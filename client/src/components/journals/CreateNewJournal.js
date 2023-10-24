import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getEmotions } from '../../managers/emotionManager.js';
import { Button, Form, FormGroup, Input, Label, Spinner, UncontrolledAlert } from "reactstrap";
import { fetchCreateNewJournal } from '../../managers/journalManager.js';
import { fetchActiveCopeStrategyByUserId } from "../../managers/strategyManager.js";


export const CreateNewJournal = ({ loggedInUser }) => {
    const navigate = useNavigate();
    const [emotions, setEmotions] = useState();
    const [activeCopeStrategy, setActiveCopeStrategy] = useState();
    const [newJournal, setNewJournal] = useState({
        journalText: '',
        copeEmotions: []
    });

    const getAllEmotions = () => {
        getEmotions().then(setEmotions);
    };

    const getUsersActiveCopeStrategy = () => {
        fetchActiveCopeStrategyByUserId(loggedInUser.id).then(setActiveCopeStrategy);
    };

    useEffect(() => {
        getAllEmotions();
        getUsersActiveCopeStrategy();
    }, []);

    const handleChange = (e) => {
        setNewJournal({
            ...newJournal,
            [e.target.name]: e.target.value,
        });
    };

    const handleCheck = (e, emotion) => {
        const isChecked = e.target.checked;

        if (isChecked) {
            let newArr = [...newJournal.copeEmotions, emotion];
            setNewJournal({
                ...newJournal,
                copeEmotions: newArr,
            });
        } else {
            setNewJournal({
                ...newJournal,
                copeEmotions: newJournal.copeEmotions.filter((ce) => ce.id !== emotion.id),
            });
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        if (
            newJournal.journalText &&
            newJournal.copeEmotions.length > 0
        ) {
            let convertedEmotionsToCopeEmotions = [];
            for (const e of newJournal.copeEmotions) {
                let newCE = {
                    emotionId: e.id,
                    emotion: e,
                };
                convertedEmotionsToCopeEmotions.push(newCE);
            }
            let newJournalToSubmit = {
                journalText: newJournal.journalText,
                copeEmotions: convertedEmotionsToCopeEmotions,
                userProfileId: loggedInUser.id,
                copeStrategyId: activeCopeStrategy.id
            };
            fetchCreateNewJournal(newJournalToSubmit).then((res) =>
                navigate(`/myjournals/${res.id}`)
            );
        }
    };

    if (!emotions) {
        return <Spinner />;
    }
    return (
        <>
            <div className="container">
                <h2>{activeCopeStrategy?.copeStrategyName}</h2>
                <h6>{activeCopeStrategy?.copeStrategyContent}</h6>
                <Form>
                    <FormGroup>
                        <Label htmlFor="journalText">Journal:</Label>
                        <Input
                            name="journalText"
                            onChange={handleChange}
                        />
                    </FormGroup>
                    <Label>How did this Coping Strategy make you feel?</Label>
                    {emotions.map((em, index) => (
                        <FormGroup
                            check
                            key={index}
                        >
                            <Label>{em.emotionName}</Label>
                            <Input
                                name={em.emotionName}
                                type="checkbox"
                                value={em.Id}
                                onChange={(e) => handleCheck(e, em)}
                                checked={!!newJournal.copeEmotions.find((copeEmotion) => copeEmotion.id === em.id)}
                            />
                        </FormGroup>
                    ))}
                </Form>
                <Button
                    onClick={handleSubmit}
                    color="primary"
                >
                    Submit
                </Button>

            </div>
        </>
    )
}