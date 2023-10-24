const _apiUrl = `/api/journal`;

export const fetchJournalsByUserId = (userId) => {
    return fetch(`${_apiUrl}/${userId}`).then((res) => res.json());
};

export const fetchCreateNewJournal = (journal) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(journal)
    }).then(res => res.json())
};
