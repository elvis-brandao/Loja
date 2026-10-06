import type { Produto } from "../types/Produto"
import type { PagedResponse } from "../types/PagedResponse"

const API_URL = "http://localhost:5035/api/produtos"

export async function obterProdutos():
  Promise<PagedResponse<Produto>>
{
  const response = await fetch(API_URL)

  if (!response.ok) {
    throw new Error("Erro ao carregar produtos")
  }

  return response.json()
}

export async function criarProduto(
  nome: string,
  preco: number
) {
  const response = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      nome,
      preco
    })
  })

  if (!response.ok) {
    throw new Error("Erro ao criar produto")
  }

  return response.json()
}

export async function excluirProduto(
  id: number
) {
  const response = await fetch(
    `${API_URL}/${id}`,
    {
      method: "DELETE"
    }
  );

  if (!response.ok) {
    throw new Error(
      "Erro ao excluir produto"
    );
  }
}

export async function atualizarProduto(
  id: number,
  nome: string,
  preco: number
) {
  const response = await fetch(
    `${API_URL}/${id}`,
    {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        nome,
        preco,
      }),
    }
  );

  if (!response.ok) {
    throw new Error(
      "Erro ao atualizar produto"
    );
  }

  return response.json();
}