const _apiUrl = `/api/copestrategy`;

export const fetchUnusedStrategiesByUserId = (userId) => {
    return fetch(`${_apiUrl}/unused/${userId}`).then(res => res.json());
};

export const fetchActiveCopeStrategyByUserId = (userId) => {
    return fetch(`${_apiUrl}/active/${userId}`).then(res => res.json());
};