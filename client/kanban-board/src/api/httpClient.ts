// MHM: Our simple http client. To update with the API, change the VITE_API_BASE_URL in kanban-board/src/.env.development

const apiBaseUrl = import.meta.env.VITE_API_BASE_URL as string;

export async function apiRequest<T>(
    path: string,
    options?: RequestInit,
): Promise<T> {
    const response = await fetch(`${apiBaseUrl}${path}`, {
        ...options,
        headers: {
            "Content-Type": "application/json",
            ...options?.headers,
        },
    });

    if (!response.ok) {
        throw new Error(
            `API request has failed! Alarm! ${response.status} ${response.statusText}`,
        );
    }

    return response.json() as Promise<T>;
}