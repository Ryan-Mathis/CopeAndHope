import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { fetchJournalById } from "../../managers/journalManager.js";
import { Button, Col, Container, Row, Spinner } from "reactstrap";

export const JournalDetails = ({ loggedInUser }) => {
    const [journal, setJournal] = useState();
    const navigate = useNavigate()
    const { id } = useParams();

    const getJournalById = () => {
        fetchJournalById(id).then(setJournal);
    }

    useEffect(() => {
        getJournalById();
    }, []);

    if (!journal) {
        return <Spinner />;
    }

    return (
            <Container fluid>
                <Row>
                    <Col>
                        <h2>{journal.copeStrategy.copeStrategyName}</h2>
                        <h6>{journal.copeStrategy.copeStrategyContent}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col xs="6" className="text-left">
                        <p>{journal.journalText}</p>
                    </Col>
                    <Col xs="6" className="d-flex justify-content-end">
                        {journal.copeEmotions.map(ce => <p>{ce.emotion.emotionName}</p>)}
                    </Col>
                </Row>
            <Button color="warning" onClick={() => navigate(`/myjournals/${journal.id}/edit`)}>Edit Journal</Button>
            </Container>
    )
}