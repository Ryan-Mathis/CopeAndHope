import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import MyJournals from "./journals/MyJournals.js";
import HomePage from "./HomePage.js";
import { CreateNewJournal } from "./journals/CreateNewJournal.js";
import { JournalDetails } from "./journals/JournalDetails.js";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <HomePage loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route> 
      <Route path="/myjournals">       
      <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <MyJournals loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <JournalDetails loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        </Route>
        <Route
          path="/newjournal"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CreateNewJournal loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
