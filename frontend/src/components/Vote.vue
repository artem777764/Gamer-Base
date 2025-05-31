<script setup lang="ts">
import MyButton from '@/components/ui/MyButton.vue';
import { computed, ref } from 'vue';
const props = defineProps<{
    id: number
    type: 'comment' | 'review'
    rating: number,
    currentMark: number
}>()

const emit = defineEmits<{
  (e: 'vote', payload: { type: 'comment' | 'review', id: number, value: number }): void
}>()

const isMinus = ref(false)
const isPlus = ref(false)

if (props.currentMark == 1) isPlus.value = true
if (props.currentMark == -1) isMinus.value = true

const baseRating = ref(props.rating)
const userMark = ref(props.currentMark)

const displayedRating = computed(() => {
  const total = baseRating.value
  return total > 0 ? `+${total}` : String(total)
})

function upVote() {
    isMinus.value = false
  if (userMark.value === 1) {
    userMark.value = 0
    baseRating.value -= 1
    isPlus.value = false
    emit('vote', { type: props.type, id: props.id, value: 0 })
  } else {
    if (userMark.value === 0) baseRating.value += 1
    else baseRating.value += 2
    userMark.value = 1
    isPlus.value = true
    emit('vote', { type: props.type, id: props.id, value: 1 })
  }
}

function downVote() {
    isPlus.value = false
  if (userMark.value === -1) {
    userMark.value = 0
    baseRating.value += 1
    isMinus.value = false
    emit('vote', { type: props.type, id: props.id, value: 0 })
  } else {
    if (userMark.value === 0) baseRating.value -= 1
    else baseRating.value -= 2
    userMark.value = -1
    isMinus.value = true
    emit('vote', { type: props.type, id: props.id, value: -1 })
  }
}
</script>

<template>
    <div class="flex flex-row gap-1 items-center">
        <MyButton @click="downVote" p="p-0" class="w-5 h-5" :class="{ 'brightness-150': isMinus }">-</MyButton>
        <p class="font-russo leading-none text-shadow text-white">{{ displayedRating }}</p>
        <MyButton @click="upVote" p="p-0" class="w-5 h-5" :class="{ 'brightness-150': isPlus }">+</MyButton>
    </div>
</template>