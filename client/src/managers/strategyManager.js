const _apiUrl = `/api/copestrategy`;

export const fetchUnusedStrategyByUserId = (userId) => {
    return fetch(`${_apiUrl}/unused/${userId}`).then(res => res.json());
};

export const fetchActiveCopeStrategyByUserId = (userId) => {
    return fetch(`${_apiUrl}/active/${userId}`).then(res => {
        if(res.ok)
        {
            return res.json();
        }
        else {
            // Promise.resolve(null);
            return null;
        }
    });
};