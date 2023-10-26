import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom"
import { getEmotions } from "../../managers/emotionManager.js";
import { fetchEditJournal, fetchJournalById, deleteJournal } from "../../managers/journalManager.js";
import { Form, Button, FormGroup, Input, Label, Spinner, Modal, ModalHeader, ModalFooter } from "reactstrap";

export const EditJournal = ({ loggedInUser }) => {
    const navigate = useNavigate();
    const { id } = useParams();
    const [emotions, setEmotions] = useState();
    const [journalToEdit, setJournalToEdit] = useState();
    const [journalId, setJournalId] = useState(0);
    const [modal, setModal] = useState(false);

    const toggle = () => {
        setModal(!modal);
      };
  
      const handleDelete = (e, id) => {
        e.preventDefault();
  
        deleteJournal(id)
          .then(navigate(`/myjournals/${id}`))
      };
  
    const getAllEmotions = () => {
        getEmotions().then(setEmotions);
    };

    const getJournalToEdit = () => {
        fetchJournalById(id).then((res) => {
            let convertedCopeEmotions = [];
            for (const ce of res.copeEmotions) {
                const emotion = {
                    id: ce.emotionId,
                    emotionName: ce.emotion.emotionName
                };
                convertedCopeEmotions.push(emotion);
            }
            setJournalToEdit({
                ...res,
                copeEmotions: convertedCopeEmotions
            });
        });
    };

    useEffect(() => {
        getAllEmotions();
        getJournalToEdit();
    }, []);

    const handleChange = (e) => {
        setJournalToEdit({
            ...journalToEdit,
            [e.target.name]: e.target.value
        });
    };

    const handleCheck = (e, emotion) => {
        const isChecked = e.target.checked;

        if (isChecked) {
            let newArr = [...journalToEdit.copeEmotions, emotion];
            setJournalToEdit({
                ...journalToEdit,
                copeEmotions: newArr,
            });
        } else {
            setJournalToEdit({
                ...journalToEdit,
                copeEmotions: journalToEdit.copeEmotions.filter((ce) => ce.id !== emotion.id),
            });
        }
    };

    const handleSubmit = () => {
        if (
            journalToEdit.journalText &&
            journalToEdit.copeEmotions.length > 0
        ) {
            let convertedEmotionsToCopeEmotions = [];
            for (const e of journalToEdit.copeEmotions) {
                let newCE = {
                    emotionId: e.id,
                    emotion: e,
                };
                convertedEmotionsToCopeEmotions.push(newCE);
            }
            let editedJournalToSubmit = {
                journalText: journalToEdit.journalText,
                journalDate: journalToEdit.journalDate,
                copeEmotions: convertedEmotionsToCopeEmotions,
                userProfileId: journalToEdit.userProfileId,
                copeStrategyId: journalToEdit.copeStrategyId
            };
            fetchEditJournal(id, editedJournalToSubmit).then((res) =>
                navigate(`/myjournals`)
            );
        }
    };

    if (!journalToEdit || !emotions) {
        return <Spinner />;
    };
    return (
        <>
            <div className="container">
                <h2>{journalToEdit.copeStrategy.copeStrategyName}</h2>
                <h6>{journalToEdit.copeStrategy.copeStrategyContent}</h6>
                <Form>
                    <FormGroup>
                        <Label htmlFor="journalText">Journal:</Label>
                        <Input
                            value={journalToEdit.journalText}
                            name="journalText"
                            onChange={handleChange}
                        />
                    </FormGroup>
                    <Label>Would you like to update how this Coping Strategy made you feel?</Label>
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
                                checked={!!journalToEdit.copeEmotions.find((copeEmotion) => copeEmotion.id === em.id)}
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
                <Button
                    onClick={() => navigate(`/myjournals/${id}`)}
                    color="secondary"
                >
                    Cancel
                </Button>
                <Button color="danger" onClick={() => {
                    toggle()
                    setJournalId(id)
                }}>
                    Delete
                </Button>
                <Modal isOpen={modal} toggle={toggle}>
                    <ModalHeader toggle={toggle}>Are you sure you want to delete this Journal?</ModalHeader>
                    <ModalFooter>
                        <Button color="danger" onClick={(e) => {
                            toggle()
                            handleDelete(e, journalId)
                        }}>
                            Confirm Deletion
                        </Button>{' '}
                        <Button color="primary" onClick={() => {
                            toggle()
                            setJournalId(0)
                        }}>
                            Cancel
                        </Button>
                    </ModalFooter>
                </Modal>

            </div>
        </>
    )
}