const _apiUrl = `/api/journal`;

export const fetchJournalsByUserId = (userId) => {
    return fetch(`${_apiUrl}/${userId}`).then((res) => res.json());
};