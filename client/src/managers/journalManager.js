const _apiUrl = `/api/journal`;

export const fetchJournalsByUserId = (userId) => {
    return fetch(`${_apiUrl}/user/${userId}`).then((res) => res.json());
};
export const fetchJournalById = (journalId) => {
    return fetch(`${_apiUrl}/${journalId}`).then((res) => res.json());
};

export const fetchCreateNewJournal = (journal) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(journal)
    }).then(res => res.json())
};

export const fetchEditJournal = (id, journal) => {
    return fetch(`${_apiUrl}/myjournals/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(journal)
    })
};
