import { useEffect, useState } from 'react';
import { fetchJournalsByUserId } from '../../managers/journalManager.js';
import { Button, Modal, ModalFooter, ModalHeader, Table } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

export default function MyJournals ({ loggedInUser }) {
    const [journals, setJournals] = useState();
    const [modal, setModal] = useState(false);
    const [journalId, setJournalId] = useState(0);

    const navigate = useNavigate();

    const getMyJournals = () => {
        fetchJournalsByUserId(loggedInUser.id).then(setJournals);
    };

    const toggle = () => {
      setModal(!modal);
    };

    const handleDelete = (e, id) => {
      e.preventDefault();

    //   deleteJournal(id)
    //     .then(() => getMyJournals())
    };
  
    useEffect(() => {
      getMyJournals();
    }, []);
  
    if (!journals){
      return null;
    }
  
    return (
      <>
        <div className="container">
          <h2>My Journals</h2>
          <Table>
            <thead>
              <th>Coping Strategy</th>
              <th>Journal</th>
              <th>Emotion</th>
              <th></th>
              <th></th>
              <th></th>
            </thead>
            <tbody>
              {journals.map((j, index) => (
                <tr key={index}>
                  <td>{j.copeStrategy.copeStrategyName}</td>
                  <td>{j.journalText}</td>
                  {j.copeEmotions.map((ce) => (
                    <td>{ce.emotion.emotionName}</td>
                  ))}
                  <td>
                    <Button color="primary" onClick={() => navigate(`/myjournals/${j.id}`)}>View Journal</Button>
                  </td>
                  {/* <td>
                    <Button color="warning" onClick={() => navigate(`/my-journals/${j.id}/edit`)}>Edit Journal</Button>
                  </td>
                  <td>
                    <Button color="danger" onClick={() => {
                      toggle() 
                      setJournalId(j.id)
                      }}>Delete</Button>
                  </td> */}
                </tr>
              ))}
            </tbody>
          </Table>
          {/* <Button onClick={() => navigate("new")}>Create New Journal</Button> */}
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
    );
  
}