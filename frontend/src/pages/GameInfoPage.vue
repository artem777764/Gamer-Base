<script setup lang="ts">
import { onMounted, ref } from 'vue';
import Card from '@/components/Card.vue';
import { useRoute } from 'vue-router';
import TextBlock from '@/components/TextBlock.vue';
import api from '@/lib/axios';

const route = useRoute()
const id = route.params.id as string

interface Game {
  Id: number
  Name: string
  Description: string
  Genres: [string]
  Developer: string
  Publisher: string
  ImageURL: string
  Platforms: [string]
  ReleaseDate: Date
  Rating: number | null
}

const game = ref<Game>()
async function fetchGameInfo(id: string)
{
    try {
        const response = await api.get(`/Games/${id}`)
        game.value = response.data
    } catch (error) {
        console.error('Ошибка при загрузке игры:', error);
    }
}

onMounted(() => {
    fetchGameInfo(id)
})
</script>

<template>
    <div class="min-h-screen bg-background px-5 pt-5">
        <p class="font-russo leading-none text-shadow text-white text-5xl text-justify">{{game?.Name}}</p>
        <div class="flex flex-row gap-5 mt-5">
            <div v-if="game" class="w-1/4 flex-shrink-0">
                <div>
                    <Card :image-src="game.ImageURL"/>
                </div>
                <div>
                    <div v-if="game.Rating">
                        <p class="font-russo leading-none text-shadow text-white text-3xl mt-1 text-center">{{game.Rating.toFixed(2)}}/5.00</p>
                        <router-link  :to="{ name: 'GameReview' }">
                            <p class="font-russo leading-none text-shadow text-white text-3xl mt-1 underline text-center">Отзывы</p>
                        </router-link>
                    </div>
                    <div v-else>
                        <p class="font-russo leading-none text-shadow text-white text-3xl mt-1 text-center">Отзывов нет</p>
                        <router-link  :to="{ name: 'GameReview' }">
                            <p class="font-russo leading-none text-shadow text-white text-3xl mt-1 underline text-center">Написать</p>
                        </router-link>
                    </div>
                </div>
            </div>
            <TextBlock>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-justify">{{ game?.Description }}</p>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-justify">Жанры: {{ game?.Genres.join(', ') }}</p>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-justify">Разработчик: {{ game?.Developer }}</p>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-justify">Издатель: {{ game?.Publisher }}</p>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-justify">Платформы: {{ game?.Platforms.join(', ') }}</p>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-justify">Дата выхода: {{ game?.ReleaseDate }}</p>
            </TextBlock>
        </div>
    </div>
</template>