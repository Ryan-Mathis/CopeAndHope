const _apiUrl = "/api/emotion"

export const getEmotions = () => {
    return fetch(_apiUrl).then(res => res.json());
}